using System;
using System.Drawing;
using Console = Colorful.Console;

namespace Mines
{
    public class OpeningScreen
    {

        public static void Credit()
        {
            Console.WriteAscii("MineSweeper",Color.Yellow);
            Console.WriteLine("                             Version 1.0");
            Console.WriteLine("                   Developed by Clint Kingston 2022");
            Console.WriteLine();
            Console.WriteLine("       Game settings can be changed in the appsettings.Json file");
            Console.WriteLine();
            Console.WriteLine("                     Ctrl + C to quit at any time");
            Console.WriteLine();
            Console.WriteLine("                    Press any key to start game...", Color.Blue);



        }
    }
}
