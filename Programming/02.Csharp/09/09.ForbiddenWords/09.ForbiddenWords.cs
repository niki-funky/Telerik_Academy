using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ForbiddenWords
{
    // We are given a string containing a list of
    // forbidden words and a text containing some 
    // of these words. Write a program that replaces
    // the forbidden words with asterisks.

    static void Main()
    {
        //variables
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        List<string> forbiddenWords = new List<string>() { "PHP", "CLR", "Microsoft" };

        Console.WriteLine(ForbiddenWord(text, forbiddenWords));
    }

    //method that finds word in text
    static string ForbiddenWord(string text, List<string> forbiddenWords)
    {
        string[] array = text.Split(new char[] { ' ' });
        StringBuilder sb = new StringBuilder();

        foreach (var word in array)
        {
            if (forbiddenWords.Any(x => x == word))
            {
                sb.Append(new String('*', word.Length) + " ");
                continue;
            }
            else if (forbiddenWords.Any(x => (x + ".") == word ))
            {
                sb.Append(new String('*', word.Length) + ".");
                continue;
            }
            else
            {
                sb.Append(word + " ");
            }
        }

        return sb.ToString();
    }
}