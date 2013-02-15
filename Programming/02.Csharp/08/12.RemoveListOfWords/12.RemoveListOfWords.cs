using System;
using System.IO;
using System.Text.RegularExpressions;

class RemoveListOfWords
{
    // Write a program that removes from a text file 
    // all words listed in given another text file. 
    // Handle all possible exceptions in your methods.

    static void Main()
    {
        try
        {
            string path = "../../text12.txt";
            string backupPath = "../../text12Backup.txt";
            string pattern = @"\b(" + String.Join("|", File.ReadAllLines("../../listOfWords.txt")) + @")\b";

            using (StreamReader sr = new StreamReader(path))
            using (StreamWriter sw = new StreamWriter("../" + path))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    sw.WriteLine(Regex.Replace(line, pattern, ""));
                    line = sr.ReadLine();
                }
            }
            //create new file,delete temp and create backup of original
            FileInfo fi = new FileInfo("../" + path);
            fi.Replace(path, backupPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oops something went wrong!" + "\n" + ex.Message);
        }
    }
}