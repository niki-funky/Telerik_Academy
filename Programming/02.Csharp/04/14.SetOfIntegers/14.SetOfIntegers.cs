using System;
using System.Linq;

class SetOfIntegers
{
    // Write methods to calculate minimum, maximum,
    // average, sum and product of given set of integer
    // numbers. Use variable number of arguments.

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
    public static int Minimum(int[] array)
    {
        int min;
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
    public static int Maximum(int[] array)
    {
        int max;
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
    public static double Average(int[] array)
    {
        double average;
        int sum = 0;
        //I variant using Linq
        average = array.Average();

        //II varint
        //for (int i = 0; i < array.Length; i++)
        //{
        //    sum = sum + array[i];
        //}
        //average = (double)sum / array.Length;

        return average;
    }

    //calculate sum of given set of integers
    public static int Sum(int[] array)
    {
        int sum = 0;
        //I variant using Linq
        sum = array.Sum();

        //II varint
        //for (int i = 0; i < array.Length; i++)
        //{
        //    sum = sum + array[i];
        //}

        return sum;
    }

    //calculate product of given set of integers
    public static int Product(int[] array)
    {
        int product = 1;
        //I variant using Linq
        product = array.Aggregate((current, next) => current * next);

        //II varint
        //for (int i = 0; i < array.Length; i++)
        //{
        //    product = product *array[i];
        //}

        return product;
    }
}
