using System;

namespace Mines
{
    class Program
    {
        static void Main(string[] args)
        {
            Minefield _ = new Minefield(10, 10);
            RandomNumber.PlaceBombs(10);
            Minefield.Neigbours();
            Minefield.PrintField();
            Userinput.getInput();
        }
    }
}
