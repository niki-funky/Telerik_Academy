using System;
using System.Linq;

class TranslateWord
{
    // A dictionary is stored as a sequence of text lines 
    // containing words and their explanations. Write a 
    // program that enters a word and translates it by
    // using the dictionary. 

    static void Main()
    {
        //variables
        string[] dictionary = {
            ".NET - platform for applications from Microsoft",
            "CLR - managed execution environment for .NET",
            "namespace - hierarchical - organization of classes"};
        string someWord = "CLR";
        string translation = null;

        //print result
        foreach (var item in dictionary)
        {
            string[] words = item.Split('-');
            if (words[0].Trim() == someWord)
            {
                translation = words[1].Trim();
            }
        }
        Console.WriteLine(translation);
    }
}