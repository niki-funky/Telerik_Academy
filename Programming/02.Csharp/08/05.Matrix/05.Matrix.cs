using System;
using System.IO;

class Matrix
{
    // Write a program that reads a text file containing
    // a square matrix of numbers and finds in the matrix
    // an area of size 2 x 2 with a maximal sum of its elements. 
    // The first line in the input file contains the size 
    // of matrix N. Each of the next N lines contain N 
    // numbers separated by space. The output should be 
    // a single number in a separate text file. 

    static void Main()
    {
        StreamReader sr = new StreamReader("../../matrix.txt");
        StreamWriter sw = new StreamWriter("../../matrixResult.txt");
        using (sw)
        {
            using (sr)
            {
                //variables
                int n = int.Parse(sr.ReadLine());
                int[,] matrix = new int[n, n];

                for (int i = 2; i <= n+1; i++)
                {
                    string[] tmp = sr.ReadLine().Split(' ');
                    for (int k = 0; k < n; k++)
                    {
                        matrix[i-2, k] = int.Parse(tmp[k]);
                    }
                }

                sw.WriteLine(MaximalSum(matrix, n));
            }
        }
    }
    // Find the maximal sum platform of size 2 x 2
    public static int MaximalSum(int[,] matrix, int n)
    {
        int bestSum = -1;
        int bestRow = 0;
        int bestCol = 0;
        for (int row = 0; row < n - 1; row++)
        {
            for (int col = 0; col < n - 1; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        return bestSum;
    }
}
