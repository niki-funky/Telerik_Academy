using System;

namespace ConsoleInputOutput
{
    class ThreeIntNumbers
    {
        //Write a program that reads 3 integer numbers 
        //from the console and prints their sum.

        static void Main()
        {
            //variables
            int firstInteger = IntFromConsole();
            int secondInteger = IntFromConsole();
            int thirdInteger = IntFromConsole();

            //expressions
            Console.WriteLine("Sum of all numbers is : {0}", (firstInteger + secondInteger + thirdInteger));
        }

        //make console red if wrong input
        static void RedLine(string value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value);

            // Reset the color
            Console.ResetColor();
        }

        //parse console input to integer
        static int IntFromConsole()
        {
            int value;
            while (true)
            {
                Console.Write("Enter a number : ");
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            return value;
        }
    }
}
