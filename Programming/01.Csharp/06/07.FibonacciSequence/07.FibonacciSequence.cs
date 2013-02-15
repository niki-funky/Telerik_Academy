using System;
namespace Loops
{
    class FibonacciSequence
    {
        //Write a program that reads a number N and 
        //calculates the sum of the first N members of the sequence of Fibonacci: 
        //0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

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
            int sum = 0;

            //expressions
            for (int i = 0; i < n; i++)
            {
                sum += Fibonacci(i);
            }
            Console.WriteLine("Sum of the first ({0}) Fibonacci members is : {1}",n, sum);
        }

        //calculate n members of the Fibonacci sequence [1...n]
        public static int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;

            for (int i = 0; i <= n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}
