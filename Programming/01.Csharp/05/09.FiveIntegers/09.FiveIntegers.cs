using System;

namespace ConditionalStatements
{
    class FiveIntegers
    {
        //We are given 5 integer numbers. 
        //Write a program that checks if the sum of some subset of them is 0. 
        //Example: 3, -2, 1, 1, 8 -> 1+1-2=0.

        static void Main()
        {
            //variables
            int[] numbers = new int[5];

            for (int i = 0; i < 5; i++)
            {
                numbers[i] = IntFromConsole();
            }

            //expressions
            //2^5=32 combinations
            for (int i = 1; i < 32; i++)
            {
                string subset = null;
                int sum = 0;
                int member;
                for (int j = 0; j < 5; j++)
                {
                    member = ((i >> j) & 1) * numbers[j];

                    if (member != 0)
                    {
                        subset = subset + " " + numbers[j].ToString("+#;-#;0");
                    }
                    sum += member;
                }
                if (sum == 0)  //cycle ends when sum of some subset is 0
                {
                    Console.WriteLine("There is a sum of subset == 0 => {0} = 0", subset);
                    return;
                }
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
