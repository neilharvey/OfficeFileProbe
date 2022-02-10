# OfficeFileProbe
Small tool to inspect format of office open XML files

## Usage

`dotnet run <path>`

The tool will dump the format as determined by [FileSignatures](https://github.com/neilharvey/FileSignatures) along with the zip entries in the file for debugging.

### Example

```
> dotnet run test.xls
FileSignatures detected format as:
xlsx [application/vnd.openxmlformats-officedocument.spreadsheetml.sheet]

Zip contains 10 entries:
xl/drawings/drawing1.xml
xl/worksheets/sheet1.xml
xl/worksheets/_rels/sheet1.xml.rels
xl/theme/theme1.xml
xl/sharedStrings.xml
xl/styles.xml
xl/workbook.xml
xl/_rels/workbook.xml.rels
_rels/.rels
[Content_Types].xml
```