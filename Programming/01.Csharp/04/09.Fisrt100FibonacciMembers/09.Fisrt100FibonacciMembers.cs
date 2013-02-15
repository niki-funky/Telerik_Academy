using System;

namespace ConsoleInputOutput
{
    class Fisrt100FibonacciMembers
    {
        //Write a program to print the first 100 members
        //of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

        static void Main()
        {
            //variables
            decimal number = 1;
            decimal previous = 0;
            decimal next = 0;

            Console.WriteLine("first 100 members of the sequence of Fibonacci : ");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine((next + ",").PadLeft(25));
                next = previous + number;
                previous= number;
                number=next;
            }
        }
    }
}
