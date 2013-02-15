using System;
using System.Linq;

class ExtractPalindromes
{
    // Write a program that extracts from a given text
    // all palindromes, e.g. "ABBA", "lamal", "exe".

    static void Main()
    {
        //variables        
        string text = "deleveled - something that goes out of level; evitative – a grammatical case indicating fear or aversion; aba – a fabric woven of the hair of camels or goats";
        string[] words = text.Split(' ', ',', '.', '-', '!', '?', ':', ';');

        foreach (var item in words)
        {
            if (item == ReverseStrings(item) && item.Length > 1)
            {
                Console.WriteLine(item);
            }
        }
    }

    public static string ReverseStrings(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}