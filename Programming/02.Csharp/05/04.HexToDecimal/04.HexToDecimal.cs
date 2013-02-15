using System;
using System.Linq;

static class HexToDecimal
{
    // Write a program to convert hexadecimal
    // numbers to their decimal representation.

    static void Main()
    {
        //variables
        string hex = "1FDE"; ;

        //print result
        Console.WriteLine(hex + " -> ");
        Console.WriteLine(HexToDecimals(hex));
    }

    //convert from hex to decimal
    public static double HexToDecimals(string hex)
    {
        //I variant
        double result = 0;
        for (int i = 0; i < hex.Length; i++)
        {
            int exp = hex.Length - i - 1;
            switch (hex.ToLower().Substring(i, 1))
            {
                case "0": result += 0 * Math.Pow(16, exp); break;
                case "1": result += 1 * Math.Pow(16, exp); break;
                case "2": result += 2 * Math.Pow(16, exp); break;
                case "3": result += 3 * Math.Pow(16, exp); break;
                case "4": result += 4 * Math.Pow(16, exp); break;
                case "5": result += 5 * Math.Pow(16, exp); break;
                case "6": result += 6 * Math.Pow(16, exp); break;
                case "7": result += 7 * Math.Pow(16, exp); break;
                case "8": result += 8 * Math.Pow(16, exp); break;
                case "9": result += 9 * Math.Pow(16, exp); break;
                case "a": result += 10 * Math.Pow(16, exp); break;
                case "b": result += 11 * Math.Pow(16, exp); break;
                case "c": result += 12 * Math.Pow(16, exp); break;
                case "d": result += 13 * Math.Pow(16, exp); break;
                case "e": result += 14 * Math.Pow(16, exp); break;
                case "f": result += 15 * Math.Pow(16, exp); break;
            }
        }

        //II variant
        //result = Convert.ToInt32(hex, 16);

        return result;
    }
}
