using System;

namespace ConsoleInputOutput
{
    class SumOfRealNumbers
    {
        //Write a program to calculate the sum 
        //(with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

        static void Main()
        {
            //variables
            decimal currentSum = 1;
            decimal previousSum = 0;

            //expression
            for (decimal i = 2; i < Decimal.MaxValue; i++)
            {
                if (i % 2 == 0)
                {
                    currentSum = currentSum + 1 / i;
                }
                else
                {
                    currentSum = currentSum - 1 / i;
                }

                if (Math.Abs(currentSum - previousSum) == 0.001m)
                {
                    break;
                }
                else
                {
                    previousSum = currentSum;
                }
            }
            Console.WriteLine(currentSum.ToString("0.000"));
            //Console.WriteLine(2-Math.Log(2)); 
        }
    }
}
