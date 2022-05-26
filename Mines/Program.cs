using System;

namespace Mines
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                while (true)
                {
                    Settings.ImportSettings();
                    Console.Title = "C# MineSweepe - By Clint Kingston";
                    MinConsoleDimensions.MinDimensionsCheck();
                    Console.Clear();
                    OpeningScreen.Credit();
                    Userinput.AnyKey();
                    Settings.ImportSettings();
                    Minefield _ = new Minefield(Settings.Rows, Settings.Cols);
                    RandomNumber.PlaceBombs(Settings.Bombs);
                    Minefield.PrintField();
                    Userinput.getInput();
                    Minefield.GameOver = false;
                }
            }
        }
    }
}
