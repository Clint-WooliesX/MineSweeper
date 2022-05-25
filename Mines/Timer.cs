using System;
namespace Mines
{
    public class Timer
    {
        public static DateTime startTime;
        public static DateTime finishTime;
        public static double elapsedTime;

        public static void StartTimer()
        {
            startTime = DateTime.Now;
        }

        public static void FinishTimer()
        {
            finishTime = DateTime.Now;
        }

        public static double ElapstedTime()
        {
            elapsedTime = DateTime.Now.Subtract(startTime).TotalSeconds;
            return elapsedTime;
        }
    }
}
