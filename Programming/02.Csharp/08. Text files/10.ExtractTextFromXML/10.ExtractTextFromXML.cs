using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractTextFromXML
{
    // Write a program that extracts from given XML
    // file all the text without the tags. 

    static void Main()
    {
        StreamReader sr = new StreamReader("../../simple.xml");
        using (sr)
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                //read all text in XML file (using Regular Expressions)
                foreach (Match item in Regex.Matches(line, @"(?<=>)[^>]*(?=<)"))
                {
                    if (item.Length != 0)
                    {
                        Console.WriteLine(item.Value);
                    }
                }
                line = sr.ReadLine();
            }
        }
    }
}