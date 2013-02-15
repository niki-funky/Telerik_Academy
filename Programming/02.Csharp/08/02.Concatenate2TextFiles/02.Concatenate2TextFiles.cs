using System;
using System.IO;
using System.Text;

class Concatenate2TextFiles
{
    // Write a program that concatenates 
    // two text files into another text file.

    static void Main()
    {
        //check if file to be written exists
        if (File.Exists("../../result.txt"))
        {
            File.Delete("../../result.txt");
        }

        StreamWriter sWriter = new StreamWriter("../../result.txt");
        using (sWriter)
        {
            //first text file
            StreamReader sReader = new StreamReader("../../text.txt");
            using (sReader)
            {
                string line = sReader.ReadLine();
                while (line != null)
                {
                    sWriter.WriteLine(line);
                    line = sReader.ReadLine();
                }
            }
            //second text file
            StreamReader sReader2 = new StreamReader("../../text2.txt");
            using (sReader2)
            {
                string line = sReader2.ReadLine();
                while (line != null)
                {
                    sWriter.WriteLine(line);
                    line = sReader2.ReadLine();
                }
            }
        }
    }
}
