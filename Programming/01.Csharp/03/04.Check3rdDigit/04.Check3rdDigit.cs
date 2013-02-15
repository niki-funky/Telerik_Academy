using System;

namespace OperatorsExpressions
{
    class Check3rdDigit
    {
        static void Main()
        {
            //Write an expression that checks for given integer
            //if its third digit (right-to-left) is 7. E. g. 1732  true.

            //variables
            int someIntNumber;
            Console.Write("Write a number to check if 3rd digit is 7: ");
            int.TryParse(Console.ReadLine(), out someIntNumber);

            //expression
            int division = someIntNumber / 100;
            bool thirdNumber = division.ToString().EndsWith("7");
            Console.WriteLine(thirdNumber);
        }
    }
}
