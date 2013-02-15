using System;

class SquareRoot
{
    // Write a program that reads an integer 
    // number and calculates and prints its 
    // square root. If the number is invalid
    // or negative, print "Invalid number". 
    // In all cases finally print "Good bye".
    // Use try-catch-finally.

    static void Main()
    {
        try
        {
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new NotImplementedException("Invalid Number");
            }
            Console.WriteLine(Math.Sqrt(number));
        }
        catch(FormatException)
        {
            Console.WriteLine("Invalid Number");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid Number");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid Number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}
