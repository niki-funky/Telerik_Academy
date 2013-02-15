using System;
using System.IO;

class ReadFile
{
    // Write a program that reads a text file 
    // and prints on the console its odd lines.

    static void Main()
    {
        StreamReader sr = new StreamReader("../../text.txt");
        using (sr)
        {
            int lineNumber = 1;
            string line = sr.ReadLine();
            while (line != null)
            {
                if (lineNumber % 2 != 0)
                {
                    Console.WriteLine(line);
                }
                lineNumber++;
                line = sr.ReadLine();
            }
        }
    }
}
