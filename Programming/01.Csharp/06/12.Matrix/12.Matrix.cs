using System;

namespace Loops
{
    class Matrix
    {
        //*Write a program that reads from the console a positive integer number N (N < 20)
        //and outputs a matrix like the following:
	    //  N = 3			N = 4
        //
        //  1 2 3         1 2 3 4
        //  2 3 4         2 3 4 5 
        //  3 4 5         3 4 5 6 
        //                4 5 6 7 

        static void Main()
        {
            //variables
            int n;
            do
            {
                Console.Write("Enter a number : ");
            }
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n >= 20);
            Console.WriteLine();

            //expressions
            for (int i = 1; i <= n; i++)
            {
                for (int k = i; k <= i+(n-1); k++)
                {
                    Console.Write("{0,3} ",k + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
