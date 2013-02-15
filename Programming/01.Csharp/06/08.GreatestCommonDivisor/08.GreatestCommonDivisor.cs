using System;

namespace Loops
{
    class GreatestCommonDivisor
    {
        //Write a program that calculates the greatest common divisor (GCD)
        //of given two numbers. Use the Euclidean algorithm (find it in Internet).

        static void Main()
        {
            //variables
            int firstNumber = IntFromConsole();
            int secondNumber = IntFromConsole();

            //expression
            Console.WriteLine("Greatest common divisor of these numbers is : {0}", GCD(firstNumber, secondNumber));
        }

        //calculate GCD using Euclidean algorithm
        static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }

            if (a == 0)
            {
                return b;
            }
            else
            {
                return a;
            }
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
