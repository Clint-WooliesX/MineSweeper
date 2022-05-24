using System;

namespace Mines
{
    class Program
    {
        static void Main(string[] args)
        {


            {
                Console.Clear();
                Settings.ImportSettings();
                Minefield _ = new Minefield(Settings.Rows, Settings.Cols);
                RandomNumber.PlaceBombs(Settings.Bombs);
                Minefield.PrintField();
                Userinput.getInput();
            }


        }
    }

}
