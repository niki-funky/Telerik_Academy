using System;

namespace ConditionalStatements
{
    class GreatestOfFiveVariables
    {
        //Write a program that finds the greatest of given 5 variables.

        static void Main()
        {
            //variables
            int first = IntFromConsole();
            int second = IntFromConsole();
            int third = IntFromConsole();
            int fourth = IntFromConsole();
            int fifth = IntFromConsole();
            int biggest=int.MinValue;

            //expressions
            if (first > biggest)
            {
                biggest = first;
            }
            if (second > biggest)
            {
                biggest = second;
            }
            if (third > biggest)
            {
                biggest = third;
            }
            if (fourth > biggest)
            {
                biggest = fourth;
            }
            if (fifth > biggest)
            {
                biggest = fifth;
            }
            Console.WriteLine("Greatest of 5 numbers is : {0}",biggest);
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
