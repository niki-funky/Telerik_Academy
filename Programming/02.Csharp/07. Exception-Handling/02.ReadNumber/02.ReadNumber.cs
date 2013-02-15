using System;

class ReadNumbers
{
    // Write a method ReadNumber(int start, int end)
    // that enters an integer number in given range 
    // [start…end]. If an invalid number or non-number 
    // text is entered, the method should throw an exception. 
    // Using this method write a program that enters 10 numbers:
    // a1, a2, … a10, such that 1 < a1 < … < a10 < 100

    static void Main()
    {
        try
        {
            for (int i = 1; i < 100; i++)
            {
                ReadNumber(1, 100);
            }
        }
        catch (FormatException fe)
        {
            Console.WriteLine("Invalid Number" + "\n" + fe.Message);
        }
        catch (ArgumentNullException ae)
        {
            Console.WriteLine("Invalid Number" + "\n" + ae.Message);
        }
        catch (OverflowException oe)
        {
            Console.WriteLine("Invalid Number" + "\n" + oe.Message);
        }
        catch (ArgumentOutOfRangeException aoe)
        {
            Console.WriteLine("Number is out of range!" + "\n" + aoe.Message);
        }
    }

    public static void ReadNumber(int start, int end)
    {
        int number = int.Parse(Console.ReadLine());
        if (number <= start || number >= end)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
