using System;
using System.Linq;
using System.Text;

class ReverseDigits
{
    // Write a method that reverses the digits of 
    // given decimal number. Example: 256 -> 652

    static void Main()
    {
        //variables
        decimal number = decimal.Parse(Console.ReadLine());

        //print result
        Console.WriteLine("Reversed number is {0}", ReverseDigit(number));
    }

    public static string ReverseDigit(decimal number)
    {
        //I variant
        var reversed = string.Join("", number.ToString().Reverse());

        //II variant
        StringBuilder sb = new StringBuilder();
        int index = 0;
        while (number > 0)
        {
            decimal d = number % 10;
            number = (number - d) / 10;
            sb.Insert(index, (char)('0' + d));
            index++;
        }

        return reversed;
        //return sb.ToString();
    }
}