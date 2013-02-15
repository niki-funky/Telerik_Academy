using System;

namespace OperatorsExpressions
{
    class ModifySomeBitInInteger
    {
        static void Main()
        {
            //We are given integer number n, 
            //value v (v=0 or 1) and a position p. 
            //Write a sequence of operators that modifies n 
            //to hold the value v at the position p from the binary representation of n.
	        //Example: n = 5 (00000101), p=3, v=1  13 (00001101)
	        //n = 5 (00000101), p=2, v=0  1 (00000001)

            //variables
            int someInt;
            int bitPosition;
            int bitValue;
            int mask;
            int maskAndSomeInteger;

            #region Console Input
            while (true)
            {
                Console.Write("Enter an Integer number: ");
                if (int.TryParse(Console.ReadLine(), out someInt))
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            while (true)
            {
                Console.Write("Enter bit position: ");
                if (int.TryParse(Console.ReadLine(), out bitPosition) && bitPosition >= 0 && bitPosition < 32)
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            while (true)
            {
                Console.Write("Enter bit value(0 or 1): ");
                if (int.TryParse(Console.ReadLine(), out bitValue) && (bitValue == 0 || bitValue == 1))
                {
                    break;
                }
                RedLine("Wrong Input!");
            }
            #endregion

            //expressions
            if (bitValue == 0)
            {
                mask = ~(1 << bitPosition);
                maskAndSomeInteger = someInt & mask;
                Console.WriteLine("Result is: "
                    + maskAndSomeInteger 
                    + " (" + Convert.ToString(maskAndSomeInteger,2).PadLeft(16,'0')
                    + ")" + "\n");
            }
            else
            {
                mask = 1 << bitPosition;
                maskAndSomeInteger = someInt | mask;
                Console.WriteLine("Result is: " 
                    + maskAndSomeInteger
                    + " (" + Convert.ToString(maskAndSomeInteger, 2).PadLeft(16, '0')                    
                    + ")" +"\n");
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
