using System;

namespace Loops
{
    class CalculateFactorial_2
    {
        //Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

        static void Main()
        {
            //variables
            int n = IntFromConsole();
            int k = IntFromConsole();
            decimal result = 1;

            //expressions
            if (k > n)
            {
                for (int i = k - n + 1; i <= k; i++, n--)
                {
                    result *= i * n;
                }
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Second number must be bigger than first number!");
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
                if (int.TryParse(Console.ReadLine(), out value) && value > 1)
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            return value;
        }
    }
}
