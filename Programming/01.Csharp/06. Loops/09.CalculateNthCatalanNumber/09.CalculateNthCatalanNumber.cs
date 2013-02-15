using System;

namespace Loops
{
    class CalculateNthCatalanNumber
    {
        //In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
        //C(n)=(2n)!/[(n+1)!n!]  n>=0;
        //Write a program to calculate the Nth Catalan number by given N.

        static void Main()
        {
            //variables
            int n;
            do
            {
                Console.Write("Enter a number : ");
            }
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            Console.WriteLine();
            decimal result = 1;              

            //expressions
            int K = n ;
            for (int i = n + 2; i <= 2 * n; i++, K--)
            {
                result *= (decimal)i / K;
            }

            Console.WriteLine("CatalanNumber ({0}) : {1:F0}", n, result);
        }
    }
}
