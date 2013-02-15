using System;
using System.Threading;

namespace ConsoleInputOutput
{
    class FallingRocks
    {
        //* Implement the "Falling Rocks" game in the text console. 
        //A small dwarf stays at the bottom of the screen and can move
        //left and right (by the arrows keys). A number of rocks of different sizes 
        //and forms constantly fall down and you need to avoid a crash.
        //Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;,
        //- distributed with appropriate density. The dwarf is (O). 
        //Ensure a constant game speed by Thread.Sleep(150).
        //Implement collision detection and scoring system.

        ///variables
        struct Coordinates                                          //color, symbol and coordinates
        {
            public int X, Y;
            public string Symbol;
            public int nSymbols;
            public ConsoleColor Color;

            public Coordinates(int x, int y, string symbol, int nSymbols, ConsoleColor Color)
            {
                this.X = x;
                this.Y = y;
                this.Symbol = symbol;
                this.nSymbols = nSymbols;
                this.Color = Color;
            }
        }

        static int dwarfPosition = (Console.WindowWidth / 2) - 1;   //dwarf X position(Y is fixed)
        static Coordinates[] rocks = new Coordinates[20];           //rock attributes
        static Random random = new Random();                        //random generator
        static char[] symbols = new char[11] { '^', '@', '*',
                '&', '+', '%', '$', '#', '!', '.', ';' };           //used symbols for rocks
        static int scores = 0;

        static void Main()
        {
            ///variables
            ConsoleKeyInfo keyInfo;
            Console.CursorVisible = false;                          //remove console cursor
            Console.BufferHeight = Console.WindowHeight;            //remove console scrollbars
            Console.BufferWidth = Console.WindowWidth;

            ///expression
            DrawDwarf(dwarfPosition, "(0)", ConsoleColor.White);
            DrawScores();
            createRocks(0, 20);

            while (true)
            {
                Console.Clear();

                //move Dwarf left and right
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            MoveDwarf(1);
                            break;
                        case ConsoleKey.LeftArrow:
                            MoveDwarf(-1);
                            break;
                    }
                }

                //generating random values for the coordinates, 
                //the color, the symbol and the size of the rocks
                for (int i = 0; i < 20; i++)
                {
                    if (rocks[i].Y == (Console.WindowHeight - 1))
                    {
                        createRocks(i, i + 1);
                    }
                    else
                    {
                        Console.SetCursorPosition(rocks[i].X, rocks[i].Y);
                        Console.Write(new String(' ', rocks[i].nSymbols));
                        rocks[i].Y++;
                    }
                    Console.SetCursorPosition(rocks[i].X, rocks[i].Y);
                    Console.ForegroundColor = rocks[i].Color;
                    Console.Write(rocks[i].Symbol);
                }

                //Collision detection
                for (int i = 0; i < 20; i++)
                {
                    if (rocks[i].nSymbols > 1)
                    {
                        for (int k = 0; k < rocks[i].nSymbols; k++)
                        {
                            if (((dwarfPosition == rocks[i].X + k) && (Console.WindowHeight - 1 == rocks[i].Y)) ||
                                ((dwarfPosition + 1 == rocks[i].X + k) && (Console.WindowHeight - 1 == rocks[i].Y)) ||
                                ((dwarfPosition + 2 == rocks[i].X + k) && (Console.WindowHeight - 1 == rocks[i].Y)))
                            {
                                DrawDwarf(dwarfPosition, "(0)", ConsoleColor.Red);
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (((dwarfPosition == rocks[i].X) && (Console.WindowHeight - 1 == rocks[i].Y)) ||
                            ((dwarfPosition == rocks[i].X - 1) && (Console.WindowHeight - 1 == rocks[i].Y)) ||
                            ((dwarfPosition == rocks[i].X - 2) && (Console.WindowHeight - 1 == rocks[i].Y)))
                        {
                            DrawDwarf(dwarfPosition, "(0)", ConsoleColor.Red);
                            return;
                        }
                    }
                    if (Console.WindowHeight - 1 == rocks[i].Y)
                    {
                        scores++;
                        DrawScores();
                    }
                }

                DrawDwarf(dwarfPosition, "(0)", ConsoleColor.White);
                DrawScores();
                Thread.Sleep(150);
            }
        }
        //creates dwarf
        static void DrawDwarf(int x, string dwarf, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, Console.WindowHeight - 1);
            Console.Write(dwarf);
        }
        //moves dwarf
        static void MoveDwarf(int x)
        {
            Coordinates newDwarf = new Coordinates()
            {
                X = dwarfPosition + x,
                Y = Console.WindowHeight - 1
            };

            if (newDwarf.X >= 0 && newDwarf.X < Console.WindowWidth - 3)
            {
                Console.SetCursorPosition(dwarfPosition, Console.WindowHeight - 1);
                Console.Write("   ");
                Console.SetCursorPosition(newDwarf.X, newDwarf.Y);
                Console.Write("(0)");

                dwarfPosition = newDwarf.X;
            }
        }
        //creates rocks
        static void createRocks(int p, int n)
        {
            for (int i = p; i < n; i++)
            {
                rocks[i].X = random.Next(1, (Console.WindowWidth - 1));
                rocks[i].Y = random.Next(1, 10);
                rocks[i].Color = (ConsoleColor)random.Next(10, 16);
                rocks[i].nSymbols = random.Next(1, 4);
                rocks[i].Symbol = new String(symbols[random.Next(1, symbols.Length)], rocks[i].nSymbols);
            }
        }
        //draws scores
        static void DrawScores()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((Console.WindowWidth / 2) - 6, 0);
            Console.Write("Scores : {0}", scores);
        }
    }
}