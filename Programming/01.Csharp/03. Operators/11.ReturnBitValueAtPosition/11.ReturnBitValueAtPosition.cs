using System;

namespace OperatorsExpressions
{
    class ReturnBitValueAtPosition
    {
        static void Main()
        {
            //Write an expression that extracts 
            //from a given integer i the value of a 
            //given bit number b. Example: i=5; b=2  value=1.

            //variables
            int someInteger;
            int bitPosition;

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
            int mask = 1 << bitPosition;
            int maskAndSomeInteger = someInteger & mask;
            int bit = maskAndSomeInteger >> bitPosition;

            Console.WriteLine("Value of bit at position({0}) is: {1}",bitPosition,bit);
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
