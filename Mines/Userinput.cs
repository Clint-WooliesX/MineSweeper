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
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(0, Minefield.X + 4);
            ConsoleKeyInfo keystroke;
            Console.WriteLine("    Row:   Col:");
            Console.SetCursorPosition(8, Minefield.X + 4);

             while(!Minefield.GameOver)
            {
                WriteTime();
                keystroke = Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Yellow;
                if ((int)keystroke.Key >= 65 && (int)keystroke.Key <= 65 + Minefield.X - 1)
                {
                    if(Coordinates.Count == 0)
                        Console.SetCursorPosition(8, Minefield.X + 4);
                    else Console.SetCursorPosition(15, Minefield.X + 4);
                    Console.WriteLine($"{keystroke.Key}");
                    Coordinates.Add((int)keystroke.Key - 65);
                }

                if (Coordinates.Count == 2 && keystroke.Key != ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("   Enter = Clear!");
                    Console.WriteLine("    Space = Flag");
                    Console.WriteLine("     Esc = Back");
                    Console.ResetColor();

                    WriteTime();
                    keystroke = Console.ReadKey(true);
                    if (keystroke.Key == ConsoleKey.Enter &&
                        !Minefield.FieldArray[Coordinates[0], Coordinates[1]].IsFlagged)
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
                    else
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

        public static void WriteTime()
        {
            while (!Console.KeyAvailable)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(17, 1);
                Console.Write($"{Timer.ElapstedTime()}s");
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
