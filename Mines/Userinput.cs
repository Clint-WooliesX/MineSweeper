﻿using System;
using System.Collections.Generic;
namespace Mines
{
    public class Userinput
    {
     public static List<int> Coordinates = new List<int>();

        public static void getInput()
        {
            Coordinates.Clear();
            ConsoleKeyInfo keystroke;
            Console.WriteLine();
            Console.WriteLine("    Row:   Col:");
            Console.SetCursorPosition(8, Minefield.X+4);
            do
            {
                keystroke = Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Yellow;
                if ((int)keystroke.Key >= 65 && (int)keystroke.Key <= 65+Minefield.X-1)
                {
                    Console.WriteLine($"{keystroke.Key}");
                    Coordinates.Add((int)keystroke.Key-65);
                    Console.SetCursorPosition(15, Minefield.X + 4);
                }
                
                if (Coordinates.Count == 2)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("   Enter = Clear!");
                    Console.WriteLine("    Space = Flag");
                    Console.WriteLine("     Esc = Back");
                    Console.ResetColor();
                    
                    {
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

                    } while(keystroke.Key != ConsoleKey.Escape);
                    return;
                }
            } while (keystroke.Key != ConsoleKey.Escape);
        }



    }
}
