using System;
namespace Mines
{
    public class Timer
    {
        public static DateTime startTime;

            public static void StartTimer()
            {
                startTime = DateTime.Now;
            }

            public static double ElapstedTime()
            {
                double elapsedTime = DateTime.Now.Subtract(startTime).TotalSeconds;
                return Math.Round(elapsedTime, 1);
            }
        }
    }
