
namespace TraverseWindowsDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string destination = @"..\..\..\exeFiles.txt";
            // not windows dir, because there is a folder(win 8)
            // called WinSxS with more than 20 000 subfolders
            string sourceDirectory = @"C:\Windows\System32";
            string fileExtesion = "*.exe";

            List<string> foundFiles = new List<string>();
            FindAllExeFiles(sourceDirectory, fileExtesion, foundFiles);

            using (StreamWriter sw = new StreamWriter(destination))
            {
                foreach (var item in foundFiles)
                {
                    sw.WriteLine(item);
                }
            }
        }

        private static void FindAllExeFiles(
            string directory, string mask, List<string> foundFiles)
        {
            try
            {
                foreach (var subDir in Directory.GetDirectories(directory))
                {
                    var filesInCurrentDirectory = Directory.EnumerateFiles(directory, mask);
                    foundFiles.AddRange(filesInCurrentDirectory);
                    FindAllExeFiles(subDir, mask, foundFiles);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
