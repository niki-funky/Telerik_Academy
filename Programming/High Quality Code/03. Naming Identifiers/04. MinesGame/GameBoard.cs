namespace MinesGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class that creates the game board and the mines
    /// and prints them
    /// </summary>
    public class GameBoard
    {
        public static void DrawBoard(char[,] gameBoard, int? mineRow = null, int? mineColumn = null)
        {
            int boardRows = gameBoard.GetLength(0);
            int boardColumns = gameBoard.GetLength(1);
            Console.WriteLine(Environment.NewLine + "    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardColumns; j++)
                {
                    if (mineRow != null && mineColumn != null && mineRow == i && mineColumn == j)
                    {
                        ColoredLine("X ");
                        continue;
                    }
                    Console.Write(string.Format("{0} ", gameBoard[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------" + Environment.NewLine);
        }

        public static char[,] CreateBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] gameBoard = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    gameBoard[i, j] = '?';
                }
            }

            return gameBoard;
        }

        public static char[,] PlaceMines()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] gameBoard = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    gameBoard[i, j] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random randomGenerator = new Random();
                int randomMine = randomGenerator.Next(50);
                if (!mines.Contains(randomMine))
                {
                    mines.Add(randomMine);
                }
            }

            foreach (int mineNumber in mines)
            {
                int column = mineNumber / boardColumns;
                int row = mineNumber % boardColumns;
                if (row == 0 && mineNumber != 0)
                {
                    column--;
                    row = boardColumns;
                }
                else
                {
                    row++;
                }

                gameBoard[column, row - 1] = '*';
            }

            return gameBoard;
        }

        private static void ColoredLine(string value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(value);
            Console.ResetColor();
        }
    }
}
