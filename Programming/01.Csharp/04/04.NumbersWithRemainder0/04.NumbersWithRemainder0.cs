using System;

namespace ConsoleInputOutput
{
    class NumbersWithRemainder0
    {
        //Write a program that reads two positive integer numbers 
        //and prints how many numbers p exist between them 
        //such that the reminder of the division by 5 is 0 (inclusive). 
        //Example: p(17,25) = 2.

        static void Main()
        {
            //variables
            int firstNumber = IntFromConsole();
            int secondNumber = IntFromConsole();
            int sumOfNumbers = 0;

            //expressions
            for (int i = firstNumber; i <= secondNumber; i++)
            {
                if (i % 5 == 0)
                {
                    sumOfNumbers++;
                }
            }

            Console.WriteLine("There are ({0}) numbers between ({1}) and ({2}) \n which have reminder of the division by 5 = 0",
                sumOfNumbers, firstNumber, secondNumber);
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
                if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            return value;
        }
    }
}
