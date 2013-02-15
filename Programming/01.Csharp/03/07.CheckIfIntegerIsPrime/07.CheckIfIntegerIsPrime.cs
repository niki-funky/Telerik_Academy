using System;

namespace OperatorsExpressions
{
    class CheckIfIntegerIsPrime
    {
        static void Main()
        {
            //Write an expression that checks 
            //if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime

            //variables
            int someInt;
            int i;
            int sumOfdeviders = 0;
            while (true)
            {
                Console.Write("Enter a number(<100) to check if it is prime number: ");
                if (int.TryParse(Console.ReadLine(), out someInt) 
                    && someInt > 0 && someInt < 100)
                {
                    break;
                }
                ColoredLine("Wrong Input!");
            }

            //expression
            for (i = 1; i <= someInt; i++)
            {
                if (someInt % i == 0)
                {
                    sumOfdeviders++;
                }
            }
            Console.WriteLine(sumOfdeviders<=2 && someInt!=2
                ? "Number is Prime." + "\n"
                : "Number is NOT Prime!" + "\n");
        }

        //make console red if wrong input
        static void ColoredLine(string value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value);

            // Reset the color
            Console.ResetColor();
        }
    }
}
