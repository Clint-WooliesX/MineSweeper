using System;
namespace Mines
{
    public class MinConsoleDimensions
    {
        public static void MinDimensionsCheck()
        {
            int minWidth = Settings.Cols;
            int minHeight = Settings.Rows;
            bool checksOK = false;
            if (CheckWidth() > minWidth && CheckHeight() > minHeight)
                checksOK = true;
            while (!checksOK)
            {
                Console.Clear();
                Console.WriteLine($"Console Dimensions:\n" +
                                  $"    Width: {CheckWidth()}\n" +
                                  $"    Height: {CheckHeight()}");
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
                    Console.WriteLine("\nResize the console!\n" +
                                      "Then press any key to check\n\n" +
                                      "minimum console ize again");
                }
                
                if (CheckWidth() > minWidth && CheckHeight() > minHeight)
                    checksOK = true;
                Userinput.AnyKey();
                Console.Title =  "C# MineSweepe - By CLint Kingston";
            } 

        }

        public static void ReturnCheck(string dimension, bool isOk)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (dimension == "width") Console.SetCursorPosition(15, 1);
            if (dimension == "height") Console.SetCursorPosition(15, 2);
            if (isOk == true) Console.Write("- OK");
            Console.ForegroundColor = ConsoleColor.Red;
            if (isOk == false) Console.Write("- Too Small");

        }

        public static int CheckWidth()
        {
            return Console.BufferWidth;

        }
        public static int CheckHeight()
        {
            return Console.BufferHeight;
        }
    }
}
