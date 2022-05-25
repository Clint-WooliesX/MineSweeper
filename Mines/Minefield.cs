using System;
using System.Collections.Generic;

namespace Mines
{
    public class Minefield
    {
        public static bool GameOver = false;
        public static int NotBombs = Settings.Cols * Settings.Rows - Settings.Bombs;
        //public static int NotBombs = Settings.Cols* Settings.Rows - Settings.Bombs;
        public static int X;
        public static int Y;
        internal static Cell[,] FieldArray;

        public Minefield(int x, int y)
        {
            //NotBombs = Settings.Cols * Settings.Rows - Settings.Bombs;
            X = x;
            Y = y;
            FieldArray = new Cell[X, Y];
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    FieldArray[i, j] = new Cell();
                }
            }
            Timer.StartTimer();
        }



        public static void PrintField()
        {
            Console.WriteLine("   C# MineSweeper");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Mines: {RandomNumber.countBombs()}   Time:{Timer.ElapstedTime()}s");
            Console.ResetColor();
            Console.WriteLine();
            int charNum = 65;
            Console.SetCursorPosition(1, 2);
            for (int y = 0; y < Y; y++)
            {
                char col = (char)charNum;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{col} ");
                charNum++;
            }
            Console.ResetColor();
            Console.WriteLine();
            charNum = 65;
            for (int x = 0; x < X; x++)
            {

                char col = (char)charNum;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{col}");
                Console.ResetColor();
                charNum++;
                for (int y = 0; y < Y; y++)
                {
                    Console.Write($"{FieldArray[x, y]} ");
                }
                Console.WriteLine();
            }
        }

        public static void Surounds(int x, int y)
        {
            //int[] xArray = new int[] { x - 1, x - 1, x - 1, x    , x    , x + 1, x + 1, x + 1 };
            //int[] yArray = new int[] { y - 1, y    , y + 1, y - 1, y + 1, y - 1, y    , y + 1 };


            int[][] coordinatArray = new int[][] {
                new int[] {x - 1,y - 1},
                new int[] {x - 1,y    },
                new int[] {x - 1,y + 1},
                new int[] {    x,y - 1},
                new int[] {    x,y + 1},
                new int[] {x + 1,y - 1},
                new int[] {x + 1,y    },
                new int[] {x + 1,y + 1},
            };


            for (int i = 0; i < 8; i++)
            {
                try { FieldArray[coordinatArray[i][0], coordinatArray[i][1]].NumBombs++; }

                catch { }
            }
        }

        public static void WinScenario()
        {
            int FlaggedBombs = 0;
            int FlaggedWrong = 0;
            int RemainingTiles = 0;

            for (int x = 0; x < Minefield.X; x++)
            {

                for (int y = 0; y < Minefield.Y; y++)
                {
                    if (Minefield.FieldArray[x, y].IsBomb == true &&
                        Minefield.FieldArray[x, y].IsFlagged == true)
                        FlaggedBombs++;
                    if (Minefield.FieldArray[x, y].IsBomb == false &&
                       Minefield.FieldArray[x, y].IsFlagged == true)
                        FlaggedWrong++;
                    if (Minefield.FieldArray[x, y].IsBomb == false &&
                       Minefield.FieldArray[x, y].IsHidden == true)
                        RemainingTiles++;
                }
            }
            if (FlaggedBombs == Settings.Bombs && FlaggedWrong == 0) Cell.YouWin();
            if (RemainingTiles == 0) Cell.YouWin();

        }
    }
}
