using System;
using System.Linq;

static class BinaryToHex
{
    // WWrite a program to convert binary 
    // numbers to hexadecimal numbers (directly).

    static void Main()
    {
        //variables
        string binary = RandomBinary(31);

        //print result
        Console.WriteLine(binary + " -> ");
        Console.WriteLine(BinToHex(binary));
    }

    //convert from binary to hex
    public static string BinToHex(string bin)
    {
        //I variant
        bin.Reverse();
        string result = String.Empty;
        for (int i = 0; i < bin.Length; i = i + 4)
        {
            string digits = String.Empty;

            digits = digits + bin.Substring(i, 4);

            switch (digits)
            {
                case "0000": result += "0"; break;
                case "0001": result += "1"; break;
                case "0010": result += "2"; break;
                case "0011": result += "3"; break;
                case "0100": result += "4"; break;
                case "0101": result += "5"; break;
                case "0110": result += "6"; break;
                case "0111": result += "7"; break;
                case "1000": result += "8"; break;
                case "1001": result += "9"; break;
                case "1010": result += "A"; break;
                case "1011": result += "B"; break;
                case "1100": result += "C"; break;
                case "1101": result += "D"; break;
                case "1110": result += "E"; break;
                case "1111": result += "F"; break;
            }
        }

        //II variant
        //result = Convert.ToString(Convert.ToInt32(hex, 16), 2);

        return result;
    }

    //generate random binary string
    public static string RandomBinary(int length)
    {
        string result = "0";
        Random rand = new Random();

        for (int i = 0; i < length; i++)
        {
            result += ((rand.Next() % 2 == 0) ? "0" : "1");
        }

        return result;
    }
}