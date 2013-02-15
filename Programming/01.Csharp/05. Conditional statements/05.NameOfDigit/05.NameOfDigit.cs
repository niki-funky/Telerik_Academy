using System;

namespace ConditionalStatements
{
    class NameOfDigit
    {
        //Write program that asks for a digit and depending on the input
        //shows the name of that digit (in English) using a switch statement.

        static void Main()
        {
            //variables
            sbyte digit;
            while (true)
            {
                Console.Write("Enter a number : ");
                if (sbyte.TryParse(Console.ReadLine(), out digit) && digit >= 0 && digit < 10)
                {
                    break;
                }
                RedLine("Wrong Input!");
            }

            //expression
            switch (digit)
            {
                case 0:
                    Console.WriteLine("zero");
                    break;
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                case 3:
                    Console.WriteLine("three");
                    break;
                case 4:
                    Console.WriteLine("four");
                    break;
                case 5:
                    Console.WriteLine("five");
                    break;
                case 6:
                    Console.WriteLine("six");
                    break;
                case 7:
                    Console.WriteLine("seven");
                    break;
                case 8:
                    Console.WriteLine("eight");
                    break;
                case 9:
                    Console.WriteLine("nine");
                    break;
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
    }
}
