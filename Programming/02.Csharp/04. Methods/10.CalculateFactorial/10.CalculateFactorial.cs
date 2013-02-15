using System;
using System.Linq;

class CalculateFactorial
{
    // Write a program to calculate n! for each n
    // in the range [1..100]. Hint: Implement first
    // a method that multiplies a number represented 
    // as array of digits by given integer number. 

    static void Main()
    {
        factorial[0] = 1;
        Range(100);
    }

    //length of factorial
    private static int length = 0;

    //array that holds the current factorial
    private static int[] factorial = new int[160];  //can be made to automatically expand

    //print current factorial
    private static void PrintResult(int[] array)
    {
        for (int k = length; k >= 0; k--)
        {
            Console.Write(factorial[k]);
        }
        Console.WriteLine();
    }

    //range of numbers [1...100]
    private static void Range(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            Multiply(i);
            PrintResult(factorial);
        }
    }

    // method that multiplies a number represented 
    // as array of digits by given integer number
    private static void Multiply(int n)
    {
        int counter;
        int carry = 0;
        int[] array = new int[length + 1];
        for (int i = 0; i <= length; i++)
        {
            array[i] = factorial[i];
        }

        for (int i = 0; i <= length; i++)
        {
            factorial[i] = (array[i] * n + carry) % 10;
            carry = (array[i] * n + carry) / 10;
        }

        counter = length + 1;
        if (carry != 0)
            while (carry != 0)
            {
                factorial[counter] = carry % 10;
                carry = carry / 10;
                counter++;
            }
        length = counter - 1;
    }
}