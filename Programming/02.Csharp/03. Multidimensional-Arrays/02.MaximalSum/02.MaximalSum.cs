using System;

class MaximalSum
{
    //Write a program that reads a rectangular matrix
    //of size N x M and finds in it the square 3 x 3 
    //that has maximal sum of its elements.

    static void Main()
    {
        //variables
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, m];
        Random rand = new Random();
        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;

        //fill the array with Random numbers
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                matrix[row, col] = rand.Next(9);
            }
        }

        #region print Matrix
        for (int row = 0; row < n; row++)
        {
            Console.Write("{");
            for (int col = 0; col < m; col++)
            {
                Console.Write(matrix[row, col]);
                if (col != m - 1)
                {
                    Console.Write(',' + " ");
                }
            }
            Console.WriteLine("}");
            Console.WriteLine();
        }
        #endregion

        // Find the maximal sum platform of size 3 x 3
        for (int row = 0; row < n - 2; row++)
        {
            for (int col = 0; col < m - 2; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1]
                    + matrix[row, col + 2] + matrix[row + 1, col]
                    + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    + matrix[row + 2, col] + matrix[row + 2, col + 1]
                    + matrix[row + 2, col + 2];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        #region print maximal sum
        //print maximal sum
        Console.WriteLine("Maximal sum for 3 x 3 elements is:");
        Console.WriteLine("  {0} {1} {2}",
            matrix[bestRow, bestCol],
            matrix[bestRow, bestCol + 1],
            matrix[bestRow, bestCol + 2]);
        Console.WriteLine("  {0} {1} {2}",
            matrix[bestRow + 1, bestCol],
            matrix[bestRow + 1, bestCol + 1],
            matrix[bestRow + 1, bestCol + 2]);
        Console.WriteLine("  {0} {1} {2}",
            matrix[bestRow + 2, bestCol],
            matrix[bestRow + 2, bestCol + 1],
            matrix[bestRow + 2, bestCol + 2]);
        Console.WriteLine("The maximal sum is: {0}", bestSum);
        #endregion
    }
}
