using System;

class BiggerOfTwoIntegers
{
    // Write a method GetMax() with two parameters that
    // returns the bigger of two integers. Write a program
    // that reads 3 integers from the console and prints 
    // the biggest of them using the method GetMax().

    static void Main()
    {
        //variables
        int[] array = new int[3];
        int biggest = 0;
        for (int i = 0; i < 3; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        //call GetMax() method for the array
        for (int i = 1; i < array.Length; i++)
        {
           biggest = GetMax(array[i - 1], array[i]);
        }
        Console.WriteLine("Biggest number si {0}",biggest);
    }

    public static int GetMax(int a, int b)
    {
        int biggest = 0;
        if (a > b)
        {
            biggest = a;
        }
        else
        {
            biggest = b;
        }
        return biggest;
    }
}
