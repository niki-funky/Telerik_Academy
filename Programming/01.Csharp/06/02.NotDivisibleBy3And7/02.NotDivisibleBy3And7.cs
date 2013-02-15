using System;

namespace Loops
{
    class NotDivisibleBy3And7
    {
        //Write a program that prints all the numbers from 1 to N, 
        //that are not divisible by 3 and 7 at the same time.

        static void Main()
        {
            //variables
            Console.Write("Enter number : ");
            int n = int.Parse(Console.ReadLine());

            //expression
            for (int i = 1; i < n; i++)
            {
                if (i % 21 > 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
