using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class CountWords
{
    // Write a program that reads a list of words
    // from a file words.txt and finds how many 
    // times each of the words is contained in another
    // file test.txt. The result should be written in 
    // the file result.txt and the words should be 
    // sorted by the number of their occurrences in
    // descending order. Handle all possible exceptions 
    // in your methods.

    static void Main()
    {
        try
        {
            //variables
            string path = "../../test.txt";
            string result = "../../result.txt";
            string[] dictionary = File.ReadAllLines("../../words.txt");
            int[] counter = new int[dictionary.Length];

            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    for (int i = 0; i < counter.Length; i++)
                    {
                        counter[i] = Regex.Matches(line, @"\b" + dictionary[i] + @"\b").Count;
                    }
                    line = sr.ReadLine();
                }
            }
            counter = counter.OrderByDescending(c => c).ToArray();

            using (StreamWriter sw = new StreamWriter(result))
            {
                for (int i = 0; i < counter.Length; i++)
                {
                    sw.WriteLine(dictionary[i] + " -> " + counter[i]);
                }                
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oops something went wrong!" + "\n" + ex.Message);
        }
    }
}