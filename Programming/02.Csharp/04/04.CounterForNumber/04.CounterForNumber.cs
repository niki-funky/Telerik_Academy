using System;
using System.Linq;

class CounterForNumber
{
    // Write a method that counts how many times given 
    // number appears in given array. Write a test program
    // to check if the method is working correctly.

    static void Main()
    {
        //variables
        int number = int.Parse(Console.ReadLine());
        int[] array = new int[10];
        Random rand = new Random();

        //fill the array with Random numbers
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(9);
        }

        #region print array
        Console.Write("{");
        Console.Write(String.Join(", ", array));
        Console.WriteLine("} -> ");
        #endregion

        //print counter
        Console.WriteLine("Number {0} was found {1} times in the array", number, Counter(array,number));
    }

    // count how many times given 
    // number appears in given array
    public static int Counter(int[] array, int number)
    {
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == number)
            {
                counter++;
            }
        }
        return counter;
    }
}