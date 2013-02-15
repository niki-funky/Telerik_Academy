using System;
using System.IO;
using System.Text;

class CompareTextFiles
{
    // WWrite a program that compares two text files
    // line by line and prints the number of lines that
    // are the same and the number of lines that are different. 
    // Assume the files have equal number of lines.

    static void Main()
    {
        StringBuilder sbEqual = new StringBuilder();
        StringBuilder sbDifferent = new StringBuilder();

        using (StreamReader sReader = new StreamReader("../../text.txt"),
            sReader2 = new StreamReader("../../text-compare.txt"))
        {
            int lineNumber = 1;
            string line1 = sReader.ReadLine();
            string line2 = sReader2.ReadLine();
            while (line1 != null)
            {
                if (line1.Equals(line2))
                {
                    sbEqual.Append(lineNumber + "; ");
                }
                else
                {
                    sbDifferent.Append(lineNumber + "; ");
                }
                line1 = sReader.ReadLine();
                line2 = sReader2.ReadLine();
                lineNumber++;
            }
        }
        Console.WriteLine("Equal lines: " + "\n" + sbEqual.ToString() + "\n");
        Console.WriteLine("Different lines: " + "\n" + sbDifferent);
    }
}
