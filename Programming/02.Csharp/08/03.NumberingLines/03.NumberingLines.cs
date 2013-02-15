using System;
using System.IO;
using System.Text;

class NumberingLines
{
    // Write a program that reads a text file and 
    // inserts line numbers in front of each of its 
    // lines. The result should be written to another text file.

    static void Main()
    {
        //check if file to be written exists
        if (File.Exists("../../numbering.txt"))
        {
            File.Delete("../../numbering.txt");
        }

        StreamWriter sWriter = new StreamWriter("../../numbering.txt");
        using (sWriter)
        {
            StreamReader sReader = new StreamReader("../../text.txt");
            using (sReader)
            {
                int lineNumber = 1;
                string line = sReader.ReadLine();
                while (line != null)
                {
                    sWriter.WriteLine(lineNumber +"." + line);
                    line = sReader.ReadLine();
                    lineNumber++;
                }
            }
        }
    }
}
