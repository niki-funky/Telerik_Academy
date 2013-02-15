using System;

namespace Loops
{
    class PrintAllNumbers1__N
    {
        //Write a program that prints all the numbers from 1 to N.

        static void Main()
        {
            //variables
            Console.Write("Enter number : ");
            int n = int.Parse(Console.ReadLine());

            //expression
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
