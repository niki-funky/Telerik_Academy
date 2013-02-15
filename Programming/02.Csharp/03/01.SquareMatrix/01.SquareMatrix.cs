using System;

class SquareMatrix
{
    //Write a program that fills and prints a matrix
    //of size (n, n) as shown below: (examples for n = 4)
    //1 5  9 13     1 8  9 16    7 11 14 16    1 12 11 10
    //2 6 10 14     2 7 10 15    4  8 12 15    2 13 16  9
    //3 7 11 15     3 6 11 14    2  5  9 13    3 14 15  8
    //4 8 12 16     4 5 12 13    1  3  6 10    4  5  6  7 

    //variables
    static int n = int.Parse(Console.ReadLine());
    static void Main()
    {
        int[,] matrix = new int[n, n];
        int columnStart, columnEnd, rowStart, rowEnd;
        columnStart = rowStart = 0;
        columnEnd = rowEnd = n - 1;
        int counter = 1;

        #region Variant a
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = counter++;
            }
        }
        PrintMatrix(matrix); 
        #endregion

        #region Variant b
        counter = 1;
        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = counter++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matrix[row, col] = counter++;
                }
            }
        }
        PrintMatrix(matrix);
        #endregion

        #region Variant c
        counter = 1;
        for (int row = n - 1; row >= 0; row--)
        {
            for (int col = 0; col < n - row; col++)
            {
                matrix[row + col, col] = counter++;
            }
        }
        for (int col = 1; col < n; col++)
        {
            for (int row = 0; row < n - col; row++)
            {
                matrix[row, col + row] = counter++;
            }
        }
        PrintMatrix(matrix);
        #endregion

        #region Variant d
        counter = 1;
        do
        {
            for (int row = rowStart; row < rowEnd; row++)           //down direction
            {
                matrix[row, columnStart] = counter++;
            }
            for (int col = columnStart; col < columnEnd; col++)           //right direction
            {
                matrix[rowEnd, col] = counter++;
            }
            for (int row = rowEnd; row > rowStart; row--)                 //up direction
            {
                matrix[row, columnEnd] = counter++;
            }
            for (int col = columnEnd; col > columnStart; col--)           //left direction
            {
                matrix[rowStart, col] = counter++;
            }
            rowStart++;
            columnStart++;
            rowEnd--;
            columnEnd--;
            if (n % 2 != 0)
            {
                matrix[rowStart, columnStart] = counter;
            }
        }
        while (counter < (n * n));
        PrintMatrix(matrix);
        #endregion
    }

    static void PrintMatrix(int[,] array)
    {
        for (int i = 0; i < n; i++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,2} ", array[i, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
