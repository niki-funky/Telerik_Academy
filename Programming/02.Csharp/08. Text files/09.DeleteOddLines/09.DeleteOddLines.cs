using System;
using System.Collections.Generic;
using System.IO;

class DeleteOddLines
{
    // Write a program that deletes from given
    // text file all odd lines. The result should 
    // be in the same file.

    static void Main()
    {
        List<string> buffer = new List<string>();
        StreamReader sr = new StreamReader("../../oddLines.txt");
        using (sr)
        {
            int lineNumber = 1;
            string line = sr.ReadLine();
            while (line != null)
            {
                if (lineNumber % 2 != 0)
                {
                    buffer.Add(line);
                }
                lineNumber++;
                line = sr.ReadLine();
            }
        }
        StreamWriter sw = new StreamWriter("../../oddLines.txt");
        using (sw)
        {
            foreach (var line in buffer)
            {
                sw.WriteLine(line);
            }
        }
    }
}