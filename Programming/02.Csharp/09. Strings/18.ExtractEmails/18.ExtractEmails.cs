using System;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractEmails
{
    // Write a program for extracting all email 
    // addresses from given text. All substrings
    // that match the format <identifier>@<host>…<domain> 
    // should be recognized as emails.

    static void Main()
    {
        //variables        
        string text = "If you have complaints or suggestions regarding Telerik services, please contact us at clientservice@telerik.com. For Sitefinity, please e-mail: clientservice@sitefinity.com.";
        var emails = Regex.Matches(text, @"");

        string[] words = text.Split(' ', ',', '.', '-', '!', '?', ':', ';');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Contains('@'))     //using Linq to find @ symbol
            {
                Console.WriteLine(words[i] + '.' + words[i + 1]);
            }
        }
    }
}