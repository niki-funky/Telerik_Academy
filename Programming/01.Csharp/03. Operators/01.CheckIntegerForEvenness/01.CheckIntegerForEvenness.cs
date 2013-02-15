using System;

namespace OperatorsExpressions
{
    class CheckIntegerForEvenness
    {
        static void Main()
        {
            //Write an expression that checks 
            //if given integer is odd or even.

            //variables
            int someInteger = 0;
            while (true)
            {
                Console.Write("Enter some integer: ");
                if (int.TryParse(Console.ReadLine(), out someInteger))
                {
                    break;
                }
                ColoredLine("Wrong Input!");
            }

            //expression
            Console.WriteLine(someInteger % 2 == 0
                ? "Integer is even." + "\n"
                : "Integer is odd" + "\n");

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
