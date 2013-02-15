using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PrintNumber
{
    // Write a program that reads a number and prints it
    // as a decimal number, hexadecimal number, percentage
    // and in scientific notation. Format the output aligned
    // right in 15 symbols.

    static void Main()
    {
        try
        {
            //variables
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Format("{0,15:D}", number));
            Console.WriteLine(string.Format("{0,15:X}", number));
            Console.WriteLine(string.Format("{0,15:P}", number));
            Console.WriteLine(string.Format("{0,15:E}", number));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}