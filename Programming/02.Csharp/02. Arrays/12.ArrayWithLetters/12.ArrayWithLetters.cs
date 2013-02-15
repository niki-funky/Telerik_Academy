using System;

class ArrayWithLetters
{
    //Write a program that creates an array containing 
    //all letters from the alphabet (A-Z). Read a word 
    //from the console and print the index of each of 
    //its letters in the array.

    static void Main()
    {
        //variables
        string word = Console.ReadLine();
        char[] alphabet = new char[26];
        //fill the array with letters
        for (int i = 0; i < 26; i++)
        {
            alphabet[i] = (char)(i+97);
        }

        //expressions
        foreach (var letter in word)
        {
            //I variant
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (letter == alphabet[i])
                {
                    Console.WriteLine("Index of letter {0} is {1}", letter, i);
                }
            }
            //II variant
            //int index = Array.IndexOf(alphabet, letter);
            //Console.WriteLine("Index of letter {0} is {1}", letter, index);
        }
    }
}
