using System;

class Compare2Arrays
{
    //Write a program that reads two arrays from 
    //the console and compares them element by element.

    static void Main()
    {
        //variables
        //int n = int.Parse(Console.ReadLine());
        //int m = int.Parse(Console.ReadLine());
        //int[] array1 = new int[n];
        //int[] array2 = new int[m];
        int[] array1 = { 1, 2, 3, 4 };
        int[] array2 = { 1, 3, 5, 4, 7, 8 };
        int equalElements = 0;

        //expressions
        ////read from console the numbers for first array
        //for (int i = 0; i < n; i++)
        //{
        //    array1[i] = int.Parse(Console.ReadLine());
        //}
        ////read from console the numbers for second array
        //for (int i = 0; i < m; i++)
        //{
        //    array2[i] = int.Parse(Console.ReadLine());
        //}

        for (int i = 0; i < (array1.Length >= array2.Length ? array2.Length : array1.Length); i++)
        {
            if (array1[i] == array2[i])
            {
                Console.WriteLine("Elements at index[{0}] from both arrays are equal.", i);
                equalElements++;
            }
            if (array1.Length == array2.Length && equalElements == array2.Length)
            {
                Console.WriteLine("Arrays are identical.");
            }
        }
        if (array1.Length != array2.Length)
        {
            Console.WriteLine("Arrays are Not identical.");
        }
    }
}

