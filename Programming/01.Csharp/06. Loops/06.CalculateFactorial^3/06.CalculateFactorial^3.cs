using System;

namespace Loops
{
    class CalculateFactorial_3
    {
        //Write a program that, for a given two integer numbers N and X, 
        //calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N

        static void Main()
        {
            //variables
            int n = IntFromConsole();
            int x = IntFromConsole();
            decimal result = 1;

            //expressions
            for (int i = 1; i <= n; i++)
            {
                result += Factorial(i) / (decimal)Math.Pow(x, i);
            }
            Console.WriteLine(result);
        }

        //calculate factorial recursively
        static decimal Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
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
                if (int.TryParse(Console.ReadLine(), out value) && value > 0 && value < 21)
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            return value;
        }
    }
}
