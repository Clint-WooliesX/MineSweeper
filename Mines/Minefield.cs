﻿using System;
using System.Collections.Generic;

namespace Mines
{
    public class Minefield
    {
        public static int X;
        public static int Y;
        internal static Cell[,] FieldArray;

        public Minefield(int x, int y)
        {
            X = x;
            Y = y;
            FieldArray = new Cell[X, Y];
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    FieldArray[i, j] = new Cell();
                }
            }
        }

        public static void PrintField()
        {
            Console.WriteLine("   C# MineSweeper");
            Console.WriteLine($"Mines: {RandomNumber.countBombs()}");
            Console.WriteLine();
            int charNum =65;
            Console.SetCursorPosition(1, 2);
            for (int y = 0; y < Y; y++)
            {
                char col = (char)charNum;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{col} ");
                charNum++;
            }
            Console.ResetColor();
            Console.WriteLine();
            charNum = 65;
            for (int x = 0; x < X; x++)
            {
                char col = (char)charNum;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{col}");
                Console.ResetColor();
                charNum++;
                for (int y = 0; y < Y; y++)
                {
                    Console.Write($"{FieldArray[x, y]} ");
                }
                Console.WriteLine();
            }
        }


        public static int Neigbours()
        {
            Console.WriteLine("  Planting the mines");
            Console.WriteLine("[                    ]");
            Console.SetCursorPosition(1, 1);
            int count = 0;
            for (int x = 0; x < X; x++)
            {
                Console.Write("\u2588");
                for (int y = 0; y < Y; y++)
                { 
                    int[] xArray = new int[] { x - 1, x - 1, x - 1, x    , x    , x + 1, x + 1, x + 1 };
                    int[] yArray = new int[] { y - 1, y    , y + 1, y - 1, y + 1, y - 1, y    , y + 1 };
                    for (int i = 0; i < 8; i++)
                    {
                        try
                        {
                            //Console.WriteLine($"{xArray[i]},{yArray[i]} checked");
                            if (FieldArray[xArray[i], yArray[i]].IsBomb)
                            {
                                count++;
                            }   
                        }
                        catch
                        {
                            //Console.WriteLine("array index out of range");
                        }
                        
                    }
                    FieldArray[x, y].NumBombs = count;
                    count = 0;
                }
                Console.Write("\u2588");
            }
            Console.Clear();
            return count;
        }
    }
}
