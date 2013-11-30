using System;
using System.Linq;

namespace EightQueensPuzzle
{
    //12. * Write a recursive program to solve the "8 Queens Puzzle" 
    // with backtracking. Learn more at: 
    // http://en.wikipedia.org/wiki/Eight_queens_puzzle

    class Program
    {
        static void Main(string[] args)
        {
            int size = 8;
            SolveQueensProblem(new bool[size, size], new int[size, size], 0);
            Console.WriteLine(count);
        }

        static int count = 0;

        static void SolveQueensProblem(
            bool[,] board, int[,] occupied, int columnIndex)
        {
            if (columnIndex == board.GetLength(0))
            {
                count++;
                return;
            }

            for (int rowIndex = 0; rowIndex < board.GetLength(0); rowIndex++)
            {
                if (occupied[rowIndex, columnIndex] == 0)
                {
                    board[rowIndex, columnIndex] = true;
                    MarkOccupied(occupied, +1, rowIndex, columnIndex);
                    SolveQueensProblem(board, occupied, columnIndex + 1);
                    board[rowIndex, columnIndex] = false;
                    MarkOccupied(occupied, -1, rowIndex, columnIndex);
                }
            }
        }

        static void MarkOccupied(
            int[,] occupied, int value, int row, int column)
        {
            for (int i = 0; i < occupied.GetLength(0); i++)
            {
                occupied[i, column] += value;
                occupied[row, i] += value;

                if (column + i < occupied.GetLength(0) &&
                    row + i < occupied.GetLength(0))
                {
                    occupied[row + i, column + i] += value;
                }
                if (column + i < occupied.GetLength(0) &&
                    row - i >= 0)
                {
                    occupied[row - i, column + i] += value;
                }

            }
        }
    }
}
