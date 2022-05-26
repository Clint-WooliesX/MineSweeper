using System;
using System.Drawing;
using Console = Colorful.Console;

namespace Mines
{
    public class OpeningScreen
    {

        public static void Credit()
        {
            Console.WriteAscii(" MineSweeper",Color.Yellow);
            Console.WriteLine("                                 Version 1.0");
            Console.WriteLine("                       Developed by Clint Kingston 2022");
            Console.WriteLine();
            Console.WriteLine("           Game settings can be changed in the appsettings.Json file");
            Console.WriteLine("            dificulty:          Rows:        Cols:        Mines:     ");
            Console.SetCursorPosition(23,10);
            Console.WriteLine($"{Settings.Diff}", Color.Green);
            Console.SetCursorPosition(38,10);
            Console.WriteLine($"{Settings.Rows}", Color.Green);
            Console.SetCursorPosition(51, 10);
            Console.WriteLine($"{Settings.Cols}", Color.Green);
            Console.SetCursorPosition(65, 10);
            Console.WriteLine($"{Settings.Bombs}", Color.Green);
            //Console.SetCursorPosition(20, 11);
            Console.WriteLine();
            Console.WriteLine("                         Ctrl + C to quit at any time");
            Console.WriteLine();
            Console.WriteLine("                        Press any key to start game...", Color.Blue);
        }
    }
}
