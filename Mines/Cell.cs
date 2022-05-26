using System;
namespace Mines
{
    public class Cell
    {
        public int NumBombs = 0;
        public bool IsBomb = false;
        public bool IsHidden = true;
        public bool IsFlagged = false;

        public Cell()
        {
        }

        public override string ToString()
        {
            if (IsFlagged == true)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                return "F";
            }

            if (IsHidden == true)
            {
                Console.ResetColor();
                return $"\u2587";
            }

            if (IsBomb == true)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                return $"\u2055";
            }

            if (NumBombs == 0)
            {
                Console.ResetColor();
                return " ";
                //return $"{NumBombs}";
            }

            Console.ResetColor();
            return $"{NumBombs}";

        }


        public static void Reveal()
        {
            int Row = Userinput.Coordinates[0];
            int Col = Userinput.Coordinates[1];
            Cell[,] Pos = Minefield.FieldArray;
            if (Pos[Row, Col].IsHidden == false)
            {
                Console.Clear();
                Minefield.PrintField();
                Minefield.WinScenario();
                if (Minefield.GameOver) return;
                Userinput.getInput();
            }
            if (Pos[Row, Col].IsBomb == true)
                YouLose();
            else
            {
                Minefield.FieldArray[Row, Col].IsHidden = false;
                Minefield.NotBombs--;
                if (Minefield.FieldArray[Row, Col].NumBombs == 0)
                {
                    CascadeZero(Row, Col);
                }
                Console.Clear();
                Minefield.PrintField();
                Minefield.WinScenario();
                Userinput.getInput();
            }
        }

        public static void Flag()
        {
            int Row = Userinput.Coordinates[0];
            int Col = Userinput.Coordinates[1];
            Cell[,] Pos = Minefield.FieldArray;
            Pos[Row, Col].IsFlagged = !Pos[Row, Col].IsFlagged;
            Minefield.WinScenario();
            Console.Clear();
            Minefield.PrintField();
            Userinput.getInput();
        }

        public static void YouWin()
        {
            Console.Clear();
            for (int i = 0; i < Minefield.X; i++)
            {
                for (int j = 0; j < Minefield.Y; j++)
                {
                    if (Minefield.FieldArray[i, j].IsBomb == true)
                    {
                        Minefield.FieldArray[i, j].IsHidden = false;
                    }
                }
            }
            Minefield.PrintField();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                   ");
            Console.WriteLine("     YOU WIN!!!    ");
            Console.WriteLine("                   ");
            Console.ResetColor();
            Console.WriteLine($"Elapsed time: {Timer.ElapstedTime()} Seconds");
            Console.WriteLine("Any Key to continue");
            Console.ResetColor();
            Minefield.GameOver = true;
            Userinput.AnyKey();
        }

        public static void YouLose()
        {
            int Row = Userinput.Coordinates[0];
            int Col = Userinput.Coordinates[1];
            Cell[,] Pos = Minefield.FieldArray;
            Pos[Row, Col].IsHidden = false;
            Console.Clear();
            for (int i = 0; i < Minefield.X; i++)
            {
                for (int j = 0; j < Minefield.Y; j++)
                {
                    if (Minefield.FieldArray[i, j].IsBomb == true)
                    {
                        Minefield.FieldArray[i, j].IsHidden = false;
                    }
                }
            }
            Minefield.PrintField();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("      BOOOM!!!     ");
            Console.WriteLine("     Game Over!    ");
            Console.ResetColor();
            Console.WriteLine($"Elapsed time: {Timer.ElapstedTime()} Seconds");
            Console.WriteLine("Any Key to continue");
            Minefield.GameOver = true;
            Userinput.AnyKey();
        }

        public static void CascadeZero(int x, int y)
        {
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
                try
                {
                    if (Minefield.FieldArray[coordinatArray[i][0], coordinatArray[i][1]].NumBombs == 0 &&
                        Minefield.FieldArray[coordinatArray[i][0], coordinatArray[i][1]].IsHidden)
                    {
                        Minefield.FieldArray[coordinatArray[i][0], coordinatArray[i][1]].IsHidden = false;
                        Minefield.NotBombs--;
                        //Console.WriteLine($"checking x{coordinatArray[i][0]}y{coordinatArray[i][1]}");
                        CascadeZero(coordinatArray[i][0], coordinatArray[i][1]);
                        
                    }
                    if (Minefield.FieldArray[coordinatArray[i][0], coordinatArray[i][1]].NumBombs > 0 &&
                       Minefield.FieldArray[coordinatArray[i][0], coordinatArray[i][1]].IsHidden) Minefield.FieldArray[coordinatArray[i][0], coordinatArray[i][1]].IsHidden = false;

                }

                catch { }
            }
        }
    }
}

