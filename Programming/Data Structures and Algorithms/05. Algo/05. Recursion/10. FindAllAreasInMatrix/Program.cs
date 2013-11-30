using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllAreasInMatrix
{
    // 10. * We are given a matrix of passable and non-passable cells. 
    // Write a recursive program for finding all areas of passable 
    // cells in the matrix.

    class Program
    {
        static char[,] matrix = 
        {
            {'.', '.', '.', '*', '.', '.', '.'},
            {'*', '*', '.', '*', '.', '*', '.'},
            {'.', '.', '.', '*', '.', '.', '.'},
            {'*', '*', '*', '*', '*', '*', '.'},
            {'.', '.', '.', '.', '.', '.', '.'},
        };

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }

        static void FindArea(int row, int col, ref int counter)
        {
            if (!InRange(row, col))
            {
                return;
            }

            if (matrix[row, col] == '.')
            {
                matrix[row, col] = '=';
                counter++;

                FindArea(row, col - 1, ref counter);
                FindArea(row - 1, col, ref counter);
                FindArea(row, col + 1, ref counter);
                FindArea(row + 1, col, ref counter);
            }
        }

        static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 2} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Main()
        {
            int counter = 0, maxCount = 0, number = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == '.')
                    {
                        FindArea(i, j, ref counter);
                        if (counter >= maxCount)
                        {
                            maxCount = counter;
                            Console.WriteLine("Area has {0} cells", maxCount);
                        }
                        counter = 0;
                    }
                }
            }

            PrintMatrix();
        }
    }
}
