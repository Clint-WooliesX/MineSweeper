using System;
using System.Collections.Generic;
namespace Mines
{
    public class RandomNumber
    {


        static public void PlaceBombs(int numBombs)
        {
            Random RndNum = new Random();
            Console.WriteLine("Planting the bombs! please wait...");

            while (countBombs()<numBombs)
            {
                List<int> col = new List<int>();
                List<int> row = new List<int>();
                int xValue = RndNum.Next(0, Minefield.X);
                while (col.Contains(xValue))
                    xValue = RndNum.Next(0, Minefield.X);
                col.Add(xValue);

                int yValue = RndNum.Next(0, Minefield.Y);
                while (row.Contains(yValue))
                    yValue = RndNum.Next(0, Minefield.Y);
                row.Add(yValue);

                Minefield.FieldArray[xValue, yValue].IsBomb = true;
                Minefield.Surounds(xValue, yValue);
            }
            Console.Clear();
        }

        static public int countBombs()
        {
            int count = 0;

            for (int x = 0; x < Minefield.X; x++)
            {

                for (int y = 0; y < Minefield.Y; y++)
                {
                    if (Minefield.FieldArray[x, y].IsBomb == true) count++;
                    if (Minefield.FieldArray[x, y].IsFlagged == true) count--;
                }
            }
            return count;
        }


    }
}
