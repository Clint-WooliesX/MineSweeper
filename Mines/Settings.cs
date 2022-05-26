using System;
using Microsoft.Extensions.Configuration;

namespace Mines
{
    public class Settings
    {
        public static string Diff;
        public static int Cols;
        public static int Rows;
        public static int Bombs;

        public static void ImportSettings()
        {
            var config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            string diff = config.GetValue<string>("MineSweeperSettings:Diff");
            int cols = config.GetValue<int>("MineSweeperSettings:Cols");
            int rows = config.GetValue<int>("MineSweeperSettings:Rows");
            int bombs = config.GetValue<int>("MineSweeperSettings:Bombs");

            Diff = diff;
            Cols = cols;
            Rows = rows;
            Bombs = bombs;
        }
    }
}
