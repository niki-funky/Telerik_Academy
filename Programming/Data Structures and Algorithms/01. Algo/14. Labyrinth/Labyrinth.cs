namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // 14. * We are given a labyrinth of size N x N. Some of its cells 
    // are empty (0) and some are full (x). We can move from an empty 
    // cell to another empty cell if they share common wall. Given a 
    // starting position (*) calculate and fill in the array the minimal
    // distance from this position to any other cell in the array. 
    // Use "u" for all unreachable cells. Example:

    // 0 | 0 | 0 | x | 0 | x            3 | 4 | 5 | x | u | x
    // 0 | x | 0 | x | 0 | x            2 | x | 6 | x | u | x
    // 0 | * | x | 0 | x | 0            1 | * | x | 8 | x | 10
    // 0 | x | 0 | 0 | 0 | 0            2 | x | 6 | 7 | 8 | 9
    // 0 | 0 | 0 | x | x | 0            3 | 4 | 5 | x | x | 10
    // 0 | 0 | 0 | x | 0 | x            4 | 5 | 6 | x | u | x 

    public class Labyrinth
    {
        public static void Main()
        {
            string[,] labyrinth = new string[,]
            {
                { "0", "0", "0", "x", "0", "x"},
                { "0", "x", "0", "x", "0", "x"},
                { "0", "*", "x", "0", "x", "0"},
                { "0", "x", "0", "0", "0", "0"},
                { "0", "0", "0", "x", "x", "0"},
                { "0", "0", "0", "x", "0", "x"},
            };

            CalculateDistances(labyrinth);
            Print(labyrinth);
        }

        private static void CalculateDistances(string[,] labyrinth)
        {
            CellInLabyrinth startCell = FindStartCell(labyrinth);
            Queue<CellInLabyrinth> emptyCells = new Queue<CellInLabyrinth>();
            emptyCells.Enqueue(startCell);
            while (emptyCells.Count > 0)
            {
                FindEmptyCell(emptyCells, labyrinth);
            }

            FillUnreachable(labyrinth);
        }

        private static void Print(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write("{0} ", matrix[row, column]);
                }
                Console.WriteLine();
            }
        }

        private static CellInLabyrinth FindStartCell(string[,] labyrinth)
        {
            int rows = labyrinth.GetLength(0);
            int columns = labyrinth.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (labyrinth[row, column] == "*")
                    {
                        return new CellInLabyrinth(row, column, "*");
                    }
                }
            }

            throw new ArgumentException("No valid starting point in labyrinth!");
        }

        private static void FillUnreachable(string[,] labyrinth)
        {
            int rows = labyrinth.GetLength(0);
            int columns = labyrinth.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (labyrinth[row, column] == "0")
                    {
                        labyrinth[row, column] = "u";
                    }
                }
            }
        }

        private static void FindEmptyCell(Queue<CellInLabyrinth> cells, string[,] labyrinth)
        {
            CellInLabyrinth current = cells.Dequeue();
            string currentWave;
            if (current.WaveValue == "*")
            {
                currentWave = "1";
            }
            else
            {
                currentWave = (Int32.Parse(current.WaveValue) + 1).ToString();
            }

            // check top cell
            CheckTopCell(current, labyrinth, currentWave, cells);

            // check left cell
            CheckLeftCell(current, labyrinth, currentWave, cells);

            // check bottom cell
            CheckBottomCell(current, labyrinth, currentWave, cells);

            // check right cell
            CheckRightCell(current, labyrinth, currentWave, cells);
        }

        private static void CheckRightCell(CellInLabyrinth current,
            string[,] labyrinth, string currentWave, Queue<CellInLabyrinth> cells)
        {
            if (current.Column < labyrinth.GetLength(1) - 1)
            {
                if (labyrinth[current.Row, current.Column + 1] == "0")
                {
                    var rightCell = new CellInLabyrinth(current.Row, current.Column + 1, currentWave);
                    cells.Enqueue(rightCell);
                    labyrinth[current.Row, current.Column + 1] = currentWave;
                }
            }
        }

        private static void CheckBottomCell(CellInLabyrinth current,
            string[,] labyrinth, string currentWave, Queue<CellInLabyrinth> cells)
        {
            if (current.Row < labyrinth.GetLength(0) - 1)
            {
                if (labyrinth[current.Row + 1, current.Column] == "0")
                {
                    var bottomCell = new CellInLabyrinth(current.Row + 1, current.Column, currentWave);
                    cells.Enqueue(bottomCell);
                    labyrinth[current.Row + 1, current.Column] = currentWave;
                }
            }
        }

        private static void CheckLeftCell(CellInLabyrinth current,
            string[,] labyrinth, string currentWave, Queue<CellInLabyrinth> cells)
        {
            if (current.Column > 0)
            {
                if (labyrinth[current.Row, current.Column - 1] == "0")
                {
                    var leftCell = new CellInLabyrinth(current.Row, current.Column - 1, currentWave);
                    cells.Enqueue(leftCell);
                    labyrinth[current.Row, current.Column - 1] = currentWave;
                }
            }
        }

        private static void CheckTopCell(CellInLabyrinth current,
            string[,] labyrinth, string currentWave, Queue<CellInLabyrinth> cells)
        {
            if (current.Row > 0)
            {
                if (labyrinth[current.Row - 1, current.Column] == "0")
                {
                    var topCell = new CellInLabyrinth(current.Row - 1, current.Column, currentWave);
                    cells.Enqueue(topCell);
                    labyrinth[current.Row - 1, current.Column] = currentWave;
                }
            }
        }
    }
}