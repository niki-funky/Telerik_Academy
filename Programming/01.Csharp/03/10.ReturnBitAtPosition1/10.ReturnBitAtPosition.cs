using System;

namespace OperatorsExpressions
{
    class ReturnBitAtPosition1
    {
        static void Main()
        {
            //Write a boolean expression that returns 
            //if the bit at position p (counting from 0) 
            //in a given integer number v has value of 1. 
            //Example: v=5; p=1  false.

            //variables
            int someInteger;
            int bitPosition;
            int mask;
            int bit;

            #region Console Input
            while (true)
            {
                Console.Write("Enter an Integer number: ");
                if (int.TryParse(Console.ReadLine(), out someInteger))
                {
                    break;
                }
                ColoredLine("Wrong Input!");
            }
            while (true)
            {
                Console.Write("Enter bit position: ");
                if (int.TryParse(Console.ReadLine(), out bitPosition))
                {
                    break;
                }
                ColoredLine("Wrong Input!");
            }
            #endregion

            //expression
            mask = 1 << bitPosition;
            bit = (someInteger & mask) >> bitPosition;

            Console.WriteLine(bit==1
                ? "True" +"\n"
                : "False" +"\n");
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
