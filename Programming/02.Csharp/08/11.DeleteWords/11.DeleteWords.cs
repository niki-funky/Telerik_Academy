using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class DeleteWords
{
    // Write a program that deletes from a 
    // text file all words that start with
    // the prefix "test". Words contain only 
    // the symbols 0...9, a...z, A…Z, _.

    static void Main()
    {
        List<string> buffer = new List<string>();
        StreamReader sr = new StreamReader("../../test.txt");
        using (sr)
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                //match words with prefix test (using Regular Expressions)
                foreach (Match item in Regex.Matches(line, @"\stest[A-Za-z0-9\-]+"))
                //foreach (Match item in Regex.Matches(line, @"(?<=^)test[A-Za-z0-9\-_]+"))
                {
                    if (item.Length != 0)
                    {
                        line = line.Replace(item.Value, "");
                    }
                }
                buffer.Add(line);
                line = sr.ReadLine();
            }
        }
        StreamWriter sw = new StreamWriter("../../test.txt");
        using (sw)
        {
            foreach (var line in buffer)
            {
                sw.WriteLine(line);
            }
        }
    }
}