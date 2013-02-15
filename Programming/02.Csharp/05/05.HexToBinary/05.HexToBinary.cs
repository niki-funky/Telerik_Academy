using System;
using System.Linq;

static class HexToBinary
{
    // Write a program to convert hexadecimal
    // numbers to binary numbers (directly).


    static void Main()
    {
        //variables
        string hex = "1FDE"; ;

        //print result
        Console.WriteLine(hex + " -> ");
        Console.WriteLine(ConvertHexToBinary(hex));
    }

    //convert from hex to binary
    public static string ConvertHexToBinary(string hex)
    {
        //I variant
        string result = String.Empty;
        for (int i = 0; i < hex.Length; i++)
        {
            switch (hex.ToLower().Substring(i, 1))
            {
                case "0": result += "0000"; break;
                case "1": result += "0001"; break;
                case "2": result += "0010"; break;
                case "3": result += "0011"; break;
                case "4": result += "0100"; break;
                case "5": result += "0101"; break;
                case "6": result += "0110"; break;
                case "7": result += "0111"; break;
                case "8": result += "1000"; break;
                case "9": result += "1001"; break;
                case "a": result += "1010"; break;
                case "b": result += "1011"; break;
                case "c": result += "1100"; break;
                case "d": result += "1101"; break;
                case "e": result += "1110"; break;
                case "f": result += "1111"; break;
            }
        }

        //II variant
        //result = Convert.ToString(Convert.ToInt32(hex, 16), 2);

        return result;
    }
}