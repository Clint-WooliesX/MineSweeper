using System;
using System.Collections.Generic;
namespace Mines
{
    public class Userinput
    {
        public static List<int> Coordinates = new List<int>();
        public static ConsoleKeyInfo keystroke;

        public static void getInput()
        {
            Coordinates.Clear();
            //if (Minefield.GameWon) return;
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(0, Minefield.X + 4);
            ConsoleKeyInfo keystroke;
            Console.WriteLine("    Row:   Col:");
            Console.SetCursorPosition(8, Minefield.X + 4);

            while(!Minefield.GameOver)
            {
                keystroke = Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Yellow;
                if ((int)keystroke.Key >= 65 && (int)keystroke.Key <= 65 + Minefield.X - 1)
                {
                    Console.WriteLine($"{keystroke.Key}");
                    Coordinates.Add((int)keystroke.Key - 65);
                    Console.SetCursorPosition(15, Minefield.X + 4);
                }

                if (Coordinates.Count == 2 && keystroke.Key != ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("   Enter = Clear!");
                    Console.WriteLine("    Space = Flag");
                    Console.WriteLine("     Esc = Back");
                    Console.ResetColor();


                    keystroke = Console.ReadKey(true);
                    if (keystroke.Key == ConsoleKey.Enter)
                    {
                        Cell.Reveal();

                    }
                    if (keystroke.Key == ConsoleKey.Spacebar)
                    {
                        Cell.Flag();

                    }
                    if (keystroke.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Minefield.PrintField();
                        getInput();
                    }

                }
            }
        }


        public static void AnyKey()
        {
            keystroke = Console.ReadKey(true);
        }

        public static void myDelay(int delaytime)
        {
            System.Threading.Thread.Sleep(delaytime);
        }

    }
}
