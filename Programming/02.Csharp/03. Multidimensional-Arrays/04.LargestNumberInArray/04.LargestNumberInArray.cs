using System;
using System.Linq;

class LargestNumberInArray
{
    //Write a program, that reads from the console 
    //an array of N integers and an integer K, sorts
    //the array and using the method Array.BinSearch()
    //finds the largest number in the array which is ≤ K. 

    static void Main()
    {
        //variables
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Random rand = new Random();
        int index;

        //fill the array with Random numbers
        for (int i = 0; i < n; i++)
        {
            array[i] = rand.Next(-9, 9);
            //array[i] = int.Parse(Console.ReadLine());
        }

        #region print array
        Console.Write("{");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i != array.Length - 1)
            {
                Console.Write(',' + " ");
            }
        }
        Console.WriteLine("}");
        #endregion

        Array.Sort(array);
        index = Array.BinarySearch(array, k);
        if (index < 0)
        {
            index = ~index - 1;
        }

        Console.WriteLine("Largest number in the array less or equal to k={0} is {1}", k, array[index]);
    }
}
