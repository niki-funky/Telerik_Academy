using System;
using System.Linq;

static class DecimalToHex
{
    // Write a program to convert decimal 
    // numbers to their hexadecimal representation.

    static void Main()
    {
        //variables
        Random rand = new Random();
        int number = rand.Next(0, 10000);       //can be anything > 0

        //print result
        Console.WriteLine(number + " -> ");
        Console.WriteLine(DecimalsToHex(number));
    }

    //convert from decimal to hex
    public static string DecimalsToHex(int number)
    {
        //I variant
        string result = "";
        int holder;
        while (number > 0)
        {
            holder = number % 16;
            result = result + holder.ToString("X");
            number = number / 16;
        }

        char[] array = result.ToCharArray();
        Array.Reverse(array);
        result = new string(array);

        //II variant
        //result = number.ToString("X");

        return result;
    }
}
