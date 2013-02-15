using System;

namespace Loops
{
    class Spiral
    {
        //* Write a program that reads a positive integer number N (N < 20)
        //from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
        //Example for N = 4
        //           1  2  3 4
        //          12 13 14 5
        //          11 16 15 6
        //          10  9  8 7

        static void Main()
        {
            //variables
            int n = 0;
            //parse console input to integer
            do
            {
                Console.Write("Enter a number : ");
            }
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n >= 20);
            Console.WriteLine();
            int rowStart = 0;
            int rowEnd = n - 1;
            int columnStart = 0;
            int columnEnd = n - 1;
            int current = 1;
            int[,] matrix = new int[n, n];

            //expressions
            do
            {
                for (int y = columnStart; y < columnEnd; y++)   //right direction
                {
                    matrix[rowStart, y] = current;
                    current++;
                }
                for (int x = rowStart; x < rowEnd; x++)         //down direction
                {
                    matrix[x, columnEnd] = current;
                    current++;
                }
                for (int y = columnEnd; y > columnStart; y--)    //left direction
                {
                    matrix[rowEnd, y] = current;
                    current++;
                }
                for (int x = rowEnd; x > rowStart; x--)        //up direction
                {
                    matrix[x, columnStart] = current;
                    current++;
                }
                rowStart++;
                columnStart++;
                rowEnd--;
                columnEnd--;
                if (n % 2 != 0)
                {
                    matrix[rowStart, columnStart] = current;
                }
            }
            while (current < (n * n));

            //print matrix on the console
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    Console.Write("{0,3} ", matrix[i, k]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
