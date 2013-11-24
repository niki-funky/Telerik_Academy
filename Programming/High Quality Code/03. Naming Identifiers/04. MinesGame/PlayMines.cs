namespace MinesGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayMines
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] gameBoard = GameBoard.CreateBoard();
            char[,] mineField = GameBoard.PlaceMines();
            int playerPoints = 0;
            bool steppedOnMine = false;
            List<GamePoints> champions = new List<GamePoints>(6);
            int row = 0;
            int column = 0;
            bool startNewGame = true;
            const int BiggestPoints = 35;
            bool isWinner = false;

            do
            {
                if (startNewGame)
                {
                    Console.WriteLine("Lets play Mines. Try your luck to find fields without mines.");
                    Console.WriteLine("Commands :");
                    Console.WriteLine("'top' -> shows current score");
                    Console.WriteLine("'restart' -> restarts the Game");
                    Console.WriteLine("'exit' -> quits the Game!");

                    GameBoard.DrawBoard(gameBoard);
                    startNewGame = false;
                }

                Console.Write("Enter row and column(or command) : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row < gameBoard.GetLength(0) &&
                        column < gameBoard.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintFinalScore(champions);
                        break;
                    case "restart":
                        gameBoard = GameBoard.CreateBoard();
                        mineField = GameBoard.PlaceMines();
                        GameBoard.DrawBoard(gameBoard);
                        steppedOnMine = false;
                        startNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, Bye!");
                        break;
                    case "turn":
                        if (mineField[row, column] != '*')
                        {
                            if (mineField[row, column] == '-')
                            {
                                PlayerMove(gameBoard, mineField, row, column);
                                playerPoints++;
                            }

                            if (BiggestPoints == playerPoints)
                            {
                                isWinner = true;
                            }
                            else
                            {
                                GameBoard.DrawBoard(gameBoard);
                            }
                        }
                        else
                        {
                            steppedOnMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine(Environment.NewLine + "Oops! Invalid command" + Environment.NewLine);
                        break;
                }

                if (steppedOnMine)
                {
                    GameBoard.DrawBoard(mineField, row, column);
                    Console.Write(
                        Environment.NewLine +
                        "Hrrrrrr! You died heroically with {0} points. " +
                        "Write your nickname: ",
                        playerPoints);

                    string playerNickName = Console.ReadLine();
                    GamePoints gamePoints = new GamePoints(playerNickName, playerPoints);
                    if (champions.Count < 5)
                    {
                        champions.Add(gamePoints);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < gamePoints.Points)
                            {
                                champions.Insert(i, gamePoints);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((GamePoints firstPlayer, GamePoints secondPlayer) => secondPlayer.NickName.CompareTo(firstPlayer.NickName));
                    champions.Sort((GamePoints firstPlayer, GamePoints secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                    PrintFinalScore(champions);

                    gameBoard = GameBoard.CreateBoard();
                    mineField = GameBoard.PlaceMines();
                    playerPoints = 0;
                    steppedOnMine = false;
                    startNewGame = true;
                }

                if (isWinner)
                {
                    Console.WriteLine(Environment.NewLine + "Congratulations! You opened 35 boxes without a drop of blood");
                    GameBoard.DrawBoard(mineField);
                    Console.WriteLine("Write your nickname, please: ");
                    string playerNickName = Console.ReadLine();
                    GamePoints gamePoints = new GamePoints(playerNickName, playerPoints);
                    champions.Add(gamePoints);
                    PrintFinalScore(champions);
                    gameBoard = GameBoard.CreateBoard();
                    mineField = GameBoard.PlaceMines();
                    playerPoints = 0;
                    isWinner = false;
                    startNewGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.Read();
        }

        /// <summary>
        /// When player moves, this method shows the number
        /// of surrounding mines
        /// </summary>
        /// <param name="gameBoard">Current game board</param>
        /// <param name="mineField">Current minefield</param>
        /// <param name="row">Number of the row, to which the player has moved</param>
        /// <param name="column">Number of the column, to which the player has moved</param>
        public static void PlayerMove(char[,] gameBoard, char[,] mineField, int row, int column)
        {
            char numberOfSurroundingMines = CountSurroundingMines(mineField, row, column);
            mineField[row, column] = numberOfSurroundingMines;
            gameBoard[row, column] = numberOfSurroundingMines;
        }

        private static void PrintFinalScore(List<GamePoints> gamePoints)
        {
            Console.WriteLine(Environment.NewLine + "Score:");
            if (gamePoints.Count > 0)
            {
                for (int i = 0; i < gamePoints.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, gamePoints[i].NickName, gamePoints[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty final score!" + Environment.NewLine);
            }
        }

        private static char CountSurroundingMines(char[,] gameBoard, int row, int column)
        {
            int surroundingMines = 0;
            int boardRows = gameBoard.GetLength(0);
            int boardColumns = gameBoard.GetLength(1);

            if (row - 1 >= 0)
            {
                if (gameBoard[row - 1, column] == '*')
                {
                    surroundingMines++;
                }
            }
            if (row + 1 < boardRows)
            {
                if (gameBoard[row + 1, column] == '*')
                {
                    surroundingMines++;
                }
            }
            if (column - 1 >= 0)
            {
                if (gameBoard[row, column - 1] == '*')
                {
                    surroundingMines++;
                }
            }
            if (column + 1 < boardColumns)
            {
                if (gameBoard[row, column + 1] == '*')
                {
                    surroundingMines++;
                }
            }
            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (gameBoard[row - 1, column - 1] == '*')
                {
                    surroundingMines++;
                }
            }
            if ((row - 1 >= 0) && (column + 1 < boardColumns))
            {
                if (gameBoard[row - 1, column + 1] == '*')
                {
                    surroundingMines++;
                }
            }
            if ((row + 1 < boardRows) && (column - 1 >= 0))
            {
                if (gameBoard[row + 1, column - 1] == '*')
                {
                    surroundingMines++;
                }
            }
            if ((row + 1 < boardRows) && (column + 1 < boardColumns))
            {
                if (gameBoard[row + 1, column + 1] == '*')
                {
                    surroundingMines++;
                }
            }

            char numberOfSurroundingMines = char.Parse(surroundingMines.ToString());

            return numberOfSurroundingMines;
        }
    }
}
