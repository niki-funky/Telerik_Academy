using System;

namespace OperatorsExpressions
{
    class ExchangeBits2
    {
        static void Main()
        {
            //* Write a program that exchanges 
            //bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1}
            //of given 32-bit unsigned integer.
            //variables
            uint someInteger;
            long firstGroup;
            int fisrtStartingBit;
            uint firstNumberOfBits;
            long secondGroup;
            int secondStartingBit;
            uint secondNumberOfBits;
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
            while (true)
            {
                Console.Write("Enter fisrtStartingBit: ");
                if (int.TryParse(Console.ReadLine(), out fisrtStartingBit))
                {                  
                    break;
                }
                RedLine("Wrong Input!");
            }
            while (true)
            {
                Console.Write("Enter firstNumberOfBits: ");
                if (uint.TryParse(Console.ReadLine(), out firstNumberOfBits))
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            while (true)
            {
                Console.Write("Enter secondStartingBit: ");
                if (int.TryParse(Console.ReadLine(), out secondStartingBit))
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            while (true)
            {
                Console.Write("Enter secondNumberOfBits: ");
                if (uint.TryParse(Console.ReadLine(), out secondNumberOfBits))
                {
                    break;
                }
                RedLine("Wrong Input!");
            }

            #endregion

            //expression
            firstGroup = (someInteger 
                & ((uint)(Math.Pow(2,firstNumberOfBits) - 1) << fisrtStartingBit));
            secondGroup = (someInteger
                & ((uint)(Math.Pow(2, secondNumberOfBits) - 1) << secondStartingBit));

            uint result1 = (uint)(someInteger ^ (firstGroup | secondGroup));
            uint result2 = (uint)(result1 | (secondGroup >> (secondStartingBit-fisrtStartingBit)));

            result = (uint)(result2 | (firstGroup << (secondStartingBit - fisrtStartingBit)));
            Console.WriteLine("Resulting number is: {0} \n{1}",
                result, Convert.ToString(result, 2).PadLeft(32, '0'));
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
