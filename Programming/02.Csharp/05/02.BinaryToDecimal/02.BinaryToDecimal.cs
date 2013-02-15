using System;
using System.Linq;

static class BinaryToDecimal
{
    // Write a program to convert binary 
    // numbers to their decimal representation.

    static void Main()
    {
        //variables
        string binary = RandomBinary(31);

        //print result
        Console.WriteLine(binary + " -> ");
        Console.WriteLine(BinToDecimal(binary));
    }

    //convert from binary to decimal
    public static int BinToDecimal(string binary)
    {
        long l = Convert.ToInt64(binary, 2);
        int i = (int)l;
        return i;
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
