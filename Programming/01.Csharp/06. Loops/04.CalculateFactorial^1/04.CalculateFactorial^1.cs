using System;

namespace Loops
{
    class CalculateFactorial_1
    {
        //Write a program that calculates N!/K! for given N and K (1<K<N).

        static void Main()
        {
            //variables
            int n = IntFromConsole();
            int k = IntFromConsole();
            decimal result = 1;

            //expression
            if (n > k)
            {
                for (int i = k + 1; i <= n; i++)
                {
                    result *= i;
                }
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("First number must be bigger than second number!");
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
