using System;
using System.Text;

class Cipher
{
    // Write a program that encodes and decodes
    // a string using given encryption key (cipher).
    // The key consists of a sequence of characters. 
    // The encoding/decoding is done by performing XOR
    // (exclusive or) operation over the first letter
    // of the string with the first of the key, the 
    // second – with the second, etc. When the last
    // key character is reached, the next is the first.

    static void Main()
    {
        //variables
        string text = Console.ReadLine();
        string cipher = "abcde";

        //encode
        text = Encode(text, cipher);
        Console.WriteLine("Encoded message: {0}", text);

        //decode
        text = Decode(text, cipher);
        Console.WriteLine("Decoded message: {0}", text);
    }

    //encoding method
    public static string Encode(string str, string cipher)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            int counter = 0;
            if (counter == cipher.Length)
            {
                counter = 0;
            }
            sb = sb.Insert(i, ((char)(str[i] ^ cipher[counter])));
            counter++;
        }
        return (sb.ToString());
    }

    //decoding method
    public static string Decode(string str, string cipher)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            int counter = 0;
            if (counter == cipher.Length)
            {
                counter = 0;
            }
            sb = sb.Insert(i, ((char)(cipher[counter] ^ str[i])));
            counter++;
        }
        return (sb.ToString());
    }
}