using System;
using System.Collections.Generic;
using System.Linq;

namespace TestIfPathExists
{
    //08. Modify the above program to check whether a path exists 
    // between two cells without finding all possible paths. 
    // Test it over an empty 100 x 100 matrix.

    class TestIfPathExists
    {
        static char[,] matrix = new char[100, 100];

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }

        static bool FindPathToExit(int row, int col)
        {
            if (!InRange(row, col))
            {
                return false;
            }

            if (matrix[row, col] == 'e')
            {
                return true;
            }

            if (matrix[row, col] == '.')
            {
                matrix[row, col] = '=';

                if (FindPathToExit(row, col - 1))
                {
                    return true;
                };
                if (FindPathToExit(row - 1, col))
                {
                    return true;
                };
                if (FindPathToExit(row, col + 1))
                {
                    return true;
                };
                if (FindPathToExit(row + 1, col))
                {
                    return true;
                };

                matrix[row, col] = '.';
            }

            return false;
        }

        public static void Main()
        {
            int rowCoord = 40;
            int colCoord = 55;

            for (int row = 0; row < 100; row++)
            {
                for (int col = 0; col < 100; col++)
                {
                    matrix[row, col] = '.';
                }
            }

            matrix[rowCoord, colCoord] = 'e';

            var result = FindPathToExit(0, 0);

            Console.WriteLine("Path exists: {0}", result);
        }
    }
}
