using System;
using System.Collections.Generic;
using System.Linq;

class ArrayOfDigits
{
    // Write a method that adds two positive integer numbers 
    // represented as arrays of digits (each array element arr[i]
    // contains a digit; the last digit is kept in arr[0]). 
    // Each of the numbers that will be added could have up to 10 000 digits.

    static void Main()
    {
        //variables
        int[] arrayOne = new int[6];
        int[] arrayTwo = new int[10];
        Random rand = new Random();

        //fill the arrays with Random numbers
        for (int i = 0; i < arrayOne.Length; i++)
        {
            arrayOne[i] = rand.Next(9);
        }
        for (int i = 0; i < arrayTwo.Length; i++)
        {
            arrayTwo[i] = rand.Next(9);
        }

        #region print arrays
        Console.Write("{ ".PadLeft(10));
        Console.Write(String.Join(",", arrayOne));
        Console.WriteLine(" }");
        Console.Write("{ ");
        Console.Write(String.Join(",", arrayTwo));
        Console.WriteLine(" }");
        Console.WriteLine();
        #endregion

        #region print result
        Console.Write("{ ");
        Console.Write(String.Join(",", AddArrays(arrayOne, arrayTwo)));   //call AddArrays method
        Console.WriteLine(" }");
        #endregion

    }

    private static List<int> AddArrays(int[] arrayOne, int[] arrayTwo)
    {
        var min = new List<int>();
        var max = new List<int>();

        if (arrayOne.Length > arrayTwo.Length)
        {
            max.AddRange(arrayOne);
            min.AddRange(arrayTwo);
        }
        else
        {
            max.AddRange(arrayTwo);
            min.AddRange(arrayOne);
        }
        List<int> result = new List<int>(max.Count + 1);

        int carry = 0;
        int sum;
        //add all numbers from min array in reverse order
        for (int i = min.Count - 1; i >= 0; i--)
        {
            sum = min[i] + max[i + max.Count - min.Count] + carry;
            if (sum >= 10)
            {
                carry = 1;
                result.Add(sum % 10);
            }
            else
            {
                result.Add(sum);
                carry = 0;
            }
        }
        //add rest of the numbers from max array in reverse order
        for (int i = max.Count - min.Count - 1; i >= 0; i--)
        {
            sum = max[i] + carry;
            if (sum >= 10)
            {
                carry = 1;
                result.Add(sum % 10);
            }
            else
            {
                result.Add(sum);
                carry = 0;
            }
        }

        if (carry == 1)
        {
            result.Add(1);
        }

        result.Reverse();
        return result;
    }
}