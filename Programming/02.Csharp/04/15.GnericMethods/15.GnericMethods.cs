using System;
using System.Collections.Generic;
using System.Linq;

class GenericMethods
{
    // * Modify your last program and try to make 
    // it work for any number type, not just integer
    // (e.g. decimal, float, byte, etc.). 
    // Use generic method (read in Internet about 
    // generic methods in C#).

    static void Main()
    {
        //variables
        int[] array = new int[10];
        Random rand = new Random();

        //fill the array with Random numbers
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(9);
        }

        //print the array
        PrintArray(array);

        //print the results
        Console.WriteLine("Minimum is : {0}", Minimum(array));
        Console.WriteLine("Maximum is : {0}", Maximum(array));
        Console.WriteLine("Average is : {0}", Average(array));
        Console.WriteLine("Sum is : {0}", Sum(array));
        Console.WriteLine("Product is : {0}", Product(array));

    }
    //print the array
    public static void PrintArray(int[] array)
    {
        Console.Write("{");
        Console.Write(String.Join(", ", array));
        Console.WriteLine("} -> ");
    }

    //calculate minimum of given set of integers
    public static T Minimum<T>(params T[] array)
    {
        dynamic min;
        //I variant using Linq
        //min = array.Min();

        //II varint
        min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }

        return min;
    }

    //calculate maximum of given set of integers
    public static T Maximum<T>(params T[] array)
    {
        dynamic max;
        //I variant using Linq
        //max = array.Max();

        //II varint
        max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }

        return max;
    }

    //calculate average of given set of integers
    public static T Average<T>(params T[] array)
    {
        dynamic average;
        dynamic sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum = sum + array[i];
        }
        average = sum / array.Length;

        return average;
    }

    //calculate sum of given set of integers
    public static T Sum<T>(params T[] array)
    {
        dynamic sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum = sum + array[i];
        }

        return sum;
    }

    //calculate product of given set of integers
    public static T Product<T>(params T[] array)
    {
        dynamic product = 1;

        for (int i = 0; i < array.Length; i++)
        {
            product = product *array[i];
        }

        return product;
    }
}
