using System;
using System.Linq;

static class DecimalToBinary
{
    // Write a program to convert decimal
    // numbers to their binary representation.

    static void Main()
    {
        //variables
        Random rand = new Random();
        int number = rand.Next(0,10000);       

        //print result
        Console.WriteLine(number + " -> ");
        Console.WriteLine(DecimalsToBinary(number));
    }

    //convert from decimal to binary
    public static string DecimalsToBinary(int number)
    {
        //I variant
        char[] array;
        string result = "";
        int holder;
        while (number > 0)
        {
            holder = number % 2;
            result = result + holder;
            number = number / 2;
        }

        array = result.ToCharArray();
        Array.Reverse(array);
        result = new string(array);

        //II variant
        //result = Convert.ToString(number, 2);

        return result;
    }
}
