using FileSignatures;
using FileSignatures.Formats;
using System.IO.Compression;

static class Program
{
    public static void Main(string[] args)
    {
        var path = args.FirstOrDefault();
        if(string.IsNullOrEmpty(path))
        {
            Console.WriteLine("Usage: OpenFileProbe.exe <file>");
            return;
        }

        if(!File.Exists(path))
        {
            Console.WriteLine("File not found: {0}", path);
            return;
        }

        var file = File.OpenRead(path);
        var inspector = new FileFormatInspector();
        var format = inspector.DetermineFileFormat(file);

        if(format is not Zip)
        {
            Console.WriteLine("File is not an Office Open XML file.");
            return;
        }

        Console.WriteLine("FileSignatures detected format as:\n{0} [{1}]", format.Extension, format.MediaType);
        Console.WriteLine();
        
        try
        {
            var zip = new ZipArchive(file);
            Console.WriteLine("Zip contains {0} entries:", zip.Entries.Count);
            foreach(var entry in zip.Entries)
            {
                Console.WriteLine(entry.FullName);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Unable to read zip entries: {0}", ex.Message);
        }
    }
}