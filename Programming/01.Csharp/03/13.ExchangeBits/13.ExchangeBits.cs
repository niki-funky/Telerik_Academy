using System;

namespace OperatorsExpressions
{
    class ExchangeBits
    {
        static void Main()
        {
            //Write a program that exchanges 
            //bits 3, 4 and 5 with bits 24, 25 and 26 
            //of given 32-bit unsigned integer.

            //variables
            uint someInteger;
            uint firstGroup;
            uint secondGroup;
            uint result;

            #region Console Input
            while (true)
            {
                Console.Write("Enter a number (>0): ");
                if (uint.TryParse(Console.ReadLine(), out someInteger))
                {
                    Console.WriteLine(Convert.ToString(someInteger, 2).PadLeft(32, '0'));
                    break;
                }
                RedLine("Wrong Input!");
            }
            #endregion

            //expressions
            firstGroup = someInteger & (7 << 3);
            secondGroup = someInteger & (7 << 24);

            uint result1 = someInteger ^ (firstGroup | secondGroup);
            uint result2 = result1 | (secondGroup >> 21);

            result = result2 | (firstGroup << 21);
            Console.WriteLine("Resulting number is: {0} \n{1}",
                result,Convert.ToString(result,2).PadLeft(32,'0'));
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
