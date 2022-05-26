using System;
namespace Mines
{
    public class MinConsoleDimensions
    {
        public static void MinDimensionsCheck()
        {
            //int minWidth = GetMinCols();      //calculated by grid size
            int minHeight = Settings.Rows + 9;
            int minWidth = 79;
            //int minHeight = 39;
            bool checksOK = false;
            if (CheckWidth() > minWidth && CheckHeight() > minHeight)
                checksOK = true;
            while (!checksOK)
            {
                Console.Clear();
                Console.WriteLine($"Console Dimensions:\n" +
                                  $"     Width:\n" +
                                  $"    Height:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(12, 1);
                Console.Write($"{CheckWidth()}");
                Console.SetCursorPosition(12, 2);
                Console.Write($"{CheckHeight()}");
                Console.ResetColor();
                if (CheckWidth() <= minWidth) ReturnCheck("width", false);
                else ReturnCheck("width", true);
                if (CheckHeight() <= minHeight) ReturnCheck("height", false);
                else ReturnCheck("height", true);
                Console.ResetColor();
                Console.SetCursorPosition(0, 3);
                if (CheckWidth() > minWidth && CheckHeight() > minHeight)
                {
                    Console.WriteLine("\nConsole Height and width are ok\n" +
                                      "Press any key to start the game.");
                }
                if (CheckWidth() <= minWidth || CheckHeight() <= minHeight)
                {
                    Console.WriteLine("\nResize the console!\n\n" +
                                      "Press any key to check\n" +
                                      "min console size again");
                }
                
                if (CheckWidth() > minWidth && CheckHeight() > minHeight)
                    checksOK = true;
                Userinput.AnyKey();
            } 

        }

        public static void ReturnCheck(string dimension, bool isOk)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (dimension == "width") Console.SetCursorPosition(0, 1);
            if (dimension == "height") Console.SetCursorPosition(0, 2);
            if (isOk == true) Console.Write(" OK");
            Console.ForegroundColor = ConsoleColor.Red;
            if (isOk == false) Console.Write(" X");

        }

        public static int CheckWidth()
        {
            return Console.BufferWidth;

        }
        public static int CheckHeight()
        {
            return Console.BufferHeight;
        }

        public static int GetMinCols()
        {
            if ((Settings.Cols * 2 + 2) < 15) return 15;
            return Settings.Cols * 2 + 2;
        }
    }
}
