using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class RemoveSentences
{
    // Write a program that extracts from a given
    // text all sentences containing given word.

    static void Main()
    {
        //variables
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string word = " in ";

        Console.WriteLine(FindSentence(text, word));
    }

    //method that finds word in sentence
    static string FindSentence(string text, string word)
    {
        string[] Sentences = text.Split(new char[] { '.' });
        StringBuilder sb = new StringBuilder();

        foreach (var sentence in Sentences)
        {
            if (sentence.Contains(word))
            {
                sb.Append(sentence + ".");
            }
        }

        return sb.ToString();
    }
}