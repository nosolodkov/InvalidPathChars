using System;
using System.IO;

namespace InvalidPathChars
{
    class Program
    {
        static void Main(string[] args)
        {
            var outFile = args.Length >= 1 ?
                args[0] :
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "InvalidNames.txt");

            // Attempt to open output file

            using (var fs = new FileStream(outFile, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(fs, System.Text.Encoding.UTF8))
                {

                    // Redirect standard output from the console to the output file.
                    Console.SetOut(writer);

                    Console.WriteLine(string.Join(" ", Path.GetInvalidFileNameChars()));
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine(string.Join(" ", Path.GetInvalidPathChars()));
                }
            }
        }
    }
}
