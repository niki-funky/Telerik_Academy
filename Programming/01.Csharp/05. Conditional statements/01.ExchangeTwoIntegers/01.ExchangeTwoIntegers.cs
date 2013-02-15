using System;

namespace ConditionalStatements
{
    class ExchangeTwoIntegers
    {
        //Write an if statement that examines two integer variables
        //and exchanges their values if the first one is greater than the second one.

        static void Main()
        {
            //variables
            int firstInt = IntFromConsole();
            int secondInt = IntFromConsole();
            int bufferInt;

            //expression
            if (firstInt > secondInt)
            {
                bufferInt = firstInt;
                firstInt = secondInt;
                secondInt = bufferInt;
            }
            Console.WriteLine("\n" + "First number is : {0}"
                + "\n" + "Second number is : {1}", firstInt, secondInt);
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

