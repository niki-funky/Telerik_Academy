using System;

namespace OperatorsExpressions
{
    class FindingBit3
    {
        //Write a boolean expression for finding if the bit 3 
        //(counting from 0) of a given integer is 1 or 0.

        static void Main()
        {
            //variables
            int intNumber;
            Console.Write("Enter a number : ");
            int.TryParse(Console.ReadLine(), out intNumber);
            int bitPosition = 3;
            int mask;


            //expression
            mask = 1 << bitPosition;
            bool paddedLeft = ((intNumber & mask) >> 3) == 1;
            Console.WriteLine("Bit 3 of the number is: {0}", paddedLeft ? 1 : 0);
        }
    }
}
