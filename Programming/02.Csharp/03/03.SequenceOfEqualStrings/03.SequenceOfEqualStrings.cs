using System;

class SequenceOfEqualStrings
{
    // We are given a matrix of strings of size N x M. 
    // Sequences in the matrix we define as sets of several 
    // neighbor elements located on the same line, column 
    // or diagonal. Write a program that finds the longest 
    // sequence of equal strings in the matrix. Example:
    //
    // ha   fifi ho  hi
    // fo   ha   hi  xx   ->  ha, ha, ha
    // xxx  ho   ha  xx

    static void Main()
    {
        //variables
        string[,] matrix = { { "ha", "fifi", "ho", "hi" },
                             { "fo", "ha", "hi", "xx" }, 
                             { "xxx", "ho", "ha", "xx" } };
        int bestRow = 0;
        int bestCol = 0;
        int bestLen = 1;
        int counter = 1;

        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        //find longest sequence
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                //check rows
                while (row + counter < n
                        && matrix[row + counter, col].Equals(matrix[row, col]))
                {
                    counter++;
                }
                if (bestLen < counter)
                {
                    bestLen = counter;
                    bestRow = row;
                    bestCol = col;
                }

                //check columns
                counter = 1;    //reset counter
                while (col + counter < n
                       && matrix[row, col + counter].Equals(matrix[row, col]))
                {
                    counter++;
                }
                if (bestLen < counter)
                {
                    bestLen = counter;
                    bestRow = row;
                    bestCol = col;
                }

                //check right diagonals
                counter = 1;    //reset counter
                while (row + counter < n && col + counter < n
                       && matrix[row + counter, col + counter].Equals(matrix[row, col]))
                {
                    counter++;
                }
                if (bestLen < counter)
                {
                    bestLen = counter;
                    bestRow = row;
                    bestCol = col;
                }

                //check left diagonals
                counter = 1;    //reset counter
                while (row - counter >= 0 && col + counter < n
                       && matrix[row - counter, col + counter].Equals(matrix[row, col]))
                {
                    counter++;
                }
                if (bestLen < counter)
                {
                    bestLen = counter;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }


        //print longest sequence
        Console.Write("Longest sequence of equal elements = { ");
        for (int i = 0; i < bestLen; i++)
        {
            Console.Write("{0} ", matrix[bestRow, bestCol]);
        }
        Console.WriteLine("}");
    }
}
