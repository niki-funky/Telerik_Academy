using System;

namespace OperatorsExpressions
{
    class FindingBit3
    {
        static void Main()
        {
            //Write a boolean expression for finding if the bit 3
            //(counting from 0) of a given integer is 1 or 0.

            //variables
            int intNumber;
            int.TryParse(Console.ReadLine(), out intNumber);

            //expression
            int paddedLeft = intNumber >> 4;
            Console.WriteLine("Bit 3 of the number is: {0}", paddedLeft.ToString().EndsWith("0") ? 0 : 1);
        }
    }
}
