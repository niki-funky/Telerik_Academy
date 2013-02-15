using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ReverseWords
{
    // Write a program that reverses the words in given sentence.
    // Example: "C# is not C++, not PHP and not Delphi!" 
    // -> "Delphi not and PHP, not C++ not is C#!".

    static void Main()
    {
        //variables
        string sentence = "C# is not C++, not PHP and not Delphi!";

        //print result
        Console.WriteLine(ReverseWordsInSentence(sentence));
    }

    //method to reverse words in sentence
    public static StringBuilder ReverseWordsInSentence(string sentence)
    {
        StringBuilder reversedSentence = new StringBuilder();
        //split sentence by punctuation
        string[] words = sentence.Split(new char[] { ' ', ',', '.', '!', '?', '-', ':', ';' },
                            StringSplitOptions.RemoveEmptyEntries);
        List<string> punctuation = new List<string>();

        //add all punctuation marks to list
        for (int i = 0; i < sentence.Length; i++)
        {
            switch (sentence[i])
            {
                case ' ':
                    punctuation.Add(" ");
                    break;
                case '.':
                    punctuation.Add(".");
                    break;
                case ',':
                    punctuation.Add(", ");
                    i++;
                    break;
                case '!':
                    punctuation.Add("!");
                    break;
                case '?':
                    punctuation.Add("?");
                    break;
                case ':':
                    punctuation.Add(": ");
                    break;
                case ';':
                    punctuation.Add("; ");
                    break;
                default:
                    break;
            }
        }
        //reverse punctuation List
        punctuation.Reverse();
        //reversing the words in the sentence
        for (int i = words.Length - 1; i >= 0; i--)
        {
            reversedSentence.Append(words[i] + punctuation[i]);
        }

        return reversedSentence;
    }
}