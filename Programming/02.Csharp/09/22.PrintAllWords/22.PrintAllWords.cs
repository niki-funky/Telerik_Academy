using System;
using System.Linq;

class PrintAllWords
{
    // Write a program that reads a string from the 
    // console and lists all different words in the 
    // string along with information how many times 
    // each word is found.

    static void Main()
    {
        //variables        
        string text = Console.ReadLine();
        string[] words = text.Split(' ', ',', '.', '-', '!', '?', ':', ';');

        //using Linq
        var wordGroups = (from x in words
                          group x by x into g       //group by distinct words
                          select new
                          {
                              ch = g.Key,           //grouping key in this case is the word itself
                              count = g.Count()     //counter for every group
                          });


        foreach (var group in wordGroups)
        {
            Console.WriteLine(group.ch + " -> " + group.count);
        }
    }
}