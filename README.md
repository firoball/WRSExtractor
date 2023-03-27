# WRSExtractor
Simple command line extractor for Acknex3 WRS files based on the work of [rickomax](https://github.com/rickomax/Acknex).
This tool is used to unpack all files inside a `.wrs` resource file which was shipped with many Acknex3 games.

**Not** compatible with newer Acknex engine versions.

## How to Build

Open _WRSExtractor.sln_ in Visual Studio and build it.

## How to use

`WRSExtractor.exe input.wrs [output folder]`

- Input file may include relative or absolute path
- Output folder defaults to `.\wrs`
