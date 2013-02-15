using System;
using System.Linq;

class Int16ToBinary
{
    // Write a program that shows the binary 
    // representation of given 16-bit signed
    // integer number (the C# type short).


    static void Main()
    {
        //variables
        Console.Write("Enter some Int16 (short) number: ");
        short s = short.Parse(Console.ReadLine());

        //print result
        Console.WriteLine(PrintResult(ShortToBinary(s)));
    }

    //print result
    public static string PrintResult(string bin)
    {
        var list = Enumerable
                  .Range(0, bin.Length / 4)
                  .Select(i => bin.Substring(i * 4, 4))
                  .ToList();
        return string.Join(" ", list);
    }

    //convert int to binary
    public static string ShortToBinary(short s)
    {
        char[] bits = new char[16];     //16 is for short
        int index = 0;

        while (s != 0)
        {
            if (index == bits.Length)
            {
                break;
            }
            bits[index++] = (s & 1) == 1 ? '1' : '0';
            s >>= 1;
        }

        Array.Reverse(bits);
        return new string(bits);
    }
}
