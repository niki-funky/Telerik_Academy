using System;
using System.Linq;

class PrintAllLetters
{
    // Write a program that reads a string from the console
    // and prints all different letters in the string along 
    // with information how many times each letter is found. 

    static void Main()
    {
        //variables        
        string text = Console.ReadLine();

        //using Linq
        var charGroups = (from x in text
                          group x by x into g       //group by char
                          select new
                         {
                             ch = g.Key,            //grouping key in this case is the char symbol itself
                             count = g.Count()      //counter for every group
                         });


        foreach (var group in charGroups)
        {
            Console.WriteLine(group.ch + " -> " + group.count);
        }
    }
}