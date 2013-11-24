using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            #region Add Indestructible Blocks as ball delimeters

            for (int row = 0; row < WorldRows; row++)
            {
                for (int col = 0; col < WorldCols; col++)
                {
                    IndestructibleBlock currBlock = null;
                    if (row == 0)
                    {
                        currBlock = new IndestructibleBlock(new MatrixCoords(row, col));
                        engine.AddObject(currBlock);
                    }
                    else
                    {
                        if (col == 0 || col == WorldCols - 1)
                        {
                            currBlock = new IndestructibleBlock(new MatrixCoords(row, col));
                            engine.AddObject(currBlock);
                        }
                    }

                }
            }
            #endregion

            #region Add TrailObject

            //TrailObject trailObject = new TrailObject(new MatrixCoords(WorldRows, WorldCols),
            //                                          new char[,] { { '°' } }, 5);
            //engine.AddObject(trailObject);

            #endregion

            #region Add Blocks

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));
                Block currBlock2 = new Block(new MatrixCoords(startRow + 1, i));
                engine.AddObject(currBlock);
                engine.AddObject(currBlock2);
            }
            #endregion

            #region Add unpassable Blocks

            //for (int i = startCol; i < endCol; i = i + 4)
            //{
            //    UnpassableBlock unpassableBlock = new UnpassableBlock(new MatrixCoords(startRow + 5, i));

            //    engine.AddObject(unpassableBlock);
            //}
            for (int i = startCol; i < endCol; i = i + 3)
            {
                UnpassableBlock unpassableBlock = new UnpassableBlock(new MatrixCoords(WorldRows - 8, i));

                engine.AddObject(unpassableBlock);
            }
            #endregion

            #region Add exploding Blocks

            for (int i = startCol; i < endCol; i = i + 1)
            {
                ExplodingBlock expoldingBlock = new ExplodingBlock(new MatrixCoords(startRow + 2, i));

                engine.AddObject(expoldingBlock);
            }
            #endregion

            #region Add gift Blocks

            for (int i = startCol; i < endCol; i++)
            {
                GiftBlock giftBlock = new GiftBlock(new MatrixCoords(startRow + 3, i));

                engine.AddObject(giftBlock);
            }
            #endregion

            #region Add Meteorite Ball

            MeteoriteBall meteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            #endregion

            #region Add unstoppableBall Ball

            UnstoppableBall unstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            #endregion

            #region Add Ball

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));
            #endregion

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            //Engine gameEngine = new Engine(renderer, keyboard, 200);
            Shooting gameEngine = new Shooting(renderer, keyboard, 200);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            //task 13
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
