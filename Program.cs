using System;
using System.IO;
using Acknex;

namespace Extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: " + typeof(Program).Assembly.GetName().Name + " input.wrs [output folder (default: .\\wrs)]");
            }
            else
            {
                string current = Directory.GetCurrentDirectory();
                string outputPath = null;
                if (args.Length > 1)
                {
                    if (Path.IsPathRooted(args[1]))
                    {
                        outputPath = Path.GetFullPath(args[1]);
                    }
                    else
                    {
                        outputPath = Path.Combine(current, Path.GetDirectoryName(args[1]));
                    }
                }
                else
                {
                    outputPath = Path.Combine(current, "wrs");
                }

                string wrsFile = Path.GetFullPath(args[0]);
                if (!File.Exists(wrsFile))
                {
                    Console.WriteLine("ERROR: " + wrsFile + " not found!");
                }
                else
                {
                    if (!Directory.Exists(outputPath))
                        Directory.CreateDirectory(outputPath);

                    Console.WriteLine("SOURCE: " + wrsFile);
                    Console.WriteLine("TARGET: " + outputPath);
                    Console.WriteLine("Start Extractor...");
                    WRSExtractor.ExtractWRS(wrsFile, outputPath);
                }
            }
        }
    }
}
