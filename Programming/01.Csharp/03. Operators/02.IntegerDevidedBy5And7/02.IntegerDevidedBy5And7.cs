using System;

namespace OperatorsExpressions
{
    class IntegerDevidedBy5And7
    {
        static void Main()
        {
            //Write a boolean expression that checks
            //for given integer if it can be divided
            //(without remainder) by 7 and 5 at the same time.

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
            Console.WriteLine(someInteger % 35 == 0
                ? "Number divides by 5 and 7 w/o remainder."+"\n"
                : "Number doesn't divide by 5 and 7 w/o remainder!" + "\n");
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
