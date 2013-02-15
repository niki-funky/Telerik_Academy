using System;
using System.Collections.Generic;
using System.IO;

class SortStrings
{
    // Write a program that reads a text file containing a 
    // list of strings, sorts them and saves them to another
    // text file. Example:
    // Ivan		->      George
    // Peter	->      Ivan
    // Maria	->      Maria
    // George	->      Peter

    static void Main()
    {
        StreamReader sr = new StreamReader("../../list.txt");
        StreamWriter sw = new StreamWriter("../../listResult.txt");
        using (sw)
        {
            using (sr)
            {
                List<string> list = new List<string>();
                string line = sr.ReadLine();

                while (line != null)
                {
                    list.Add(line);
                    line = sr.ReadLine();
                }

                list.Sort();
                //File.WriteAllLines("../../../listResult.txt", list);
                foreach (var item in list)
                {
                    sw.WriteLine(item);
                }
            }
        }
    }
}