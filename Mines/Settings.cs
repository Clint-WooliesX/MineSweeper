using System;
using Microsoft.Extensions.Configuration;

namespace Mines
{
    public class Settings
    {
        public static int Cols;
        public static int Rows;
        public static int Bombs;

        public static void ImportSettings()
        {
            var config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json").Build();

            int cols = config.GetValue<int>("MineSweeperSettings:Cols");
            int rows = config.GetValue<int>("MineSweeperSettings:Rows");
            int bombs = config.GetValue<int>("MineSweeperSettings:Bombs");

            Cols = cols;
            Rows = rows;
            Bombs = bombs;
        }
    }
}
