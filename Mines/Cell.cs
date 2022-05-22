using System;
namespace Mines
{
    public class Cell
    {
        public int NumBombs=0;
        public bool IsBomb=false;
        public bool IsHidden=true;
        public bool IsFlagged = false;

        public Cell()
        {
        }

        public override string ToString()
        {
            if (IsFlagged == true)
                return "F";

            if (IsHidden == true) {
            return $"\u2588"; 
            }
            //return $"\u2048";

            if (IsBomb == true)
                return $"\u2055";

            return $"{NumBombs}";

        }

        public static void Reveal()
        {
            int Row = Userinput.Coordinates[0];
            int Col = Userinput.Coordinates[1];
            Cell[,] Pos = Minefield.FieldArray;
            if (Pos[Row, Col].IsBomb == true)
            {
                Pos[Row, Col].IsHidden = false;
                Console.Clear();
                Minefield.PrintField();
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("     BOOOM!!!     ");
                Console.WriteLine("    Game Over!    ");

            }
            else
            {
                Minefield.FieldArray[Row, Col].IsHidden = false;
                Console.Clear();
                Minefield.PrintField();
                Userinput.getInput();
            }
        }

        public static void Flag()
        {
            int Row = Userinput.Coordinates[0];
            int Col = Userinput.Coordinates[1];
            Cell[,] Pos = Minefield.FieldArray;
            Pos[Row, Col].IsFlagged = true;
            Console.Clear();
            Minefield.PrintField();
            Userinput.getInput();

        }

    }
}
