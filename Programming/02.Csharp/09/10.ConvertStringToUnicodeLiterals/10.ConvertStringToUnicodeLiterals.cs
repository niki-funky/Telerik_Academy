using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ConvertStringToUnicodeLiterals
{
    // Write a program that converts a string to
    // a sequence of C# Unicode character literals.
    // Use format strings. 

    static void Main()
    {
        //variables
        string text = "Hi!";

        Console.WriteLine(ConvertToUnicode(text));
    }

    //method that finds word in text
    static string ConvertToUnicode(string text)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var bt in text)
        {
            sb.AppendFormat("\\u{0:X4}", (int)bt);
        }

        return sb.ToString();
    }
}