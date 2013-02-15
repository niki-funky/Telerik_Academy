using System;

class PrintListOfWords
{
    // Write a program that reads a list of words,
    // separated by spaces and prints the list in an 
    // alphabetical order.

    static void Main()
    {
        //variables        
        string text = Console.ReadLine();
        string[] words = text.Split(' ');
        Array.Sort(words);

        foreach (var item in words)
        {
            Console.WriteLine(item);
        }
    }
}