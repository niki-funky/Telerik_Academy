using System;

namespace ConditionalStatements
{
    class BiggestOfThreeIntegers
    {
        //Write a program that finds the biggest of three integers
        //using nested if statements.

        static void Main()
        {
            //variables
            int firstint = IntFromConsole();
            int secondInt = IntFromConsole();
            int thirdInt = IntFromConsole();
            int biggestInt = 0;

            //expressions
            if (firstint < secondInt)
            {
                if (secondInt < thirdInt)
                {
                    biggestInt = thirdInt;
                }
                else
                {
                    biggestInt = secondInt;
                }
            }
            else
            {
                if (firstint < thirdInt)
                {
                    biggestInt = thirdInt;
                }
                else
                {
                    biggestInt = firstint;
                }
            }
            Console.WriteLine("Biggest Number is : {0}",biggestInt);
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
