using System;
using System.Collections.Generic;
using System.Linq;

namespace FindAllPathsInMatrix
{
    //07. We are given a matrix of passable and non-passable cells. 
    // Write a recursive program for finding all paths between 
    // two cells in the matrix.

    class AllPathsInLabyrinth
    {
        static char[,] matrix = 
        {
            {'.', '.', '.', '*', '.', '.', '.'},
            {'*', '*', '.', '*', '.', '*', '.'},
            {'.', '.', '.', '.', '.', '.', '.'},
            {'.', '*', '*', '*', '*', '*', '.'},
            {'.', '.', '.', '.', '.', '.', 'e'},
        };

        static List<string> path = new List<string>();

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }

        static void FindPathToExit(int row, int col, int counter)
        {
            if (!InRange(row, col))
            {
                return;
            }

            path.Add(counter.ToString());

            if (matrix[row, col] == 'e')
            {
                PrintMatrix(path);
            }

            if (matrix[row, col] == '.')
            {
                matrix[row, col] = '=';
                counter++;

                FindPathToExit(row, col - 1, counter);
                FindPathToExit(row - 1, col, counter);
                FindPathToExit(row, col + 1, counter);
                FindPathToExit(row + 1, col, counter);

                matrix[row, col] = '.';
            }

            path.RemoveAt(path.Count - 1);
        }

        static void PrintMatrix(List<string> path)
        {
            Console.WriteLine("Path length: {0}", path.Count);
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
            FindPathToExit(0, 0, 0);
        }
    }
}
