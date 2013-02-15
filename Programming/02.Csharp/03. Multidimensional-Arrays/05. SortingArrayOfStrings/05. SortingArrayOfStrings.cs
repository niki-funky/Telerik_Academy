using System;
using System.Linq;

class SortingArrayOfStrings
{
    // You are given an array of strings. Write a method
    // that sorts the array by the length of its elements
    // (the number of characters composing them).

    static void Main()
    {
        //variables
        string[] array = new string[7];
        Random rand = new Random();

        //fill the Array with Random strings
        for (int i = 0; i < array.Length; i++)
        {
            string member = null;
            for (int k = 0; k < rand.Next(1, 7); k++)     //length of strings
            {
                member = member + RandomString();
            }
            array[i] = member;
        }

        #region print original array
        Console.Write("{");
        Console.Write(String.Join(", ", array));
        Console.WriteLine("} -> ");
        #endregion

        //sort the array by the length of its elements
        var SortedArray = array.OrderBy(x => x.Length);     //using Linq

        #region print sorted array
        Console.Write("{");
        Console.Write(String.Join(", ", SortedArray));
        Console.WriteLine("} ");
        #endregion
    }

    #region Generate Random strings
    private static Random Random = new Random();
    //Generate Random string
    private static string RandomString()
    {
        char letter = (char)Random.Next(0x41, 0x5A);
        return letter.ToString();
    }
    #endregion
}
