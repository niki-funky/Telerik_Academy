using System;

class ReverseString
{
    // Write a program that reads a string, reverses it
    // and prints the result at the console.
    // Example: "sample" -> "elpmas".

    static void Main()
    {
        //variables
        string word = Console.ReadLine();

        //print result
        Console.WriteLine(ReverseStrings(word));
    }

    public static string ReverseStrings(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}
