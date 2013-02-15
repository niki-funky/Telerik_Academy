using System;
using System.Text;

class ConsecutiveLetters
{
    // Write a program that reads a string from 
    // the console and replaces all series of 
    // consecutive identical letters with a single 
    // one. Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".


    static void Main()
    {
        //variables        
        string text = "aaaaabbbbbcdddeeeedssaa";
        StringBuilder sb = new StringBuilder();
        char currentChar = '@';

        foreach (var item in text)
        {
            if (item != currentChar)
            {
                sb.Append(item);
                currentChar = item;
            }
        }

        Console.WriteLine(sb.ToString());
    }
}