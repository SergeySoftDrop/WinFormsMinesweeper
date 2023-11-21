using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using сапёр3.Controllers;
using Сапёр3.Setings;

namespace сапёр3.Setings
{
    static class SetingsPreset
    {
        public static void Easy()
        {
            GameSetings.MapSize[0] = 9;
            GameSetings.MapSize[1] = 9;

            GameSetings.BombsQuantity = 5;
        }

        public static void Middle()
        {
            GameSetings.MapSize[0] = 12;
            GameSetings.MapSize[1] = 12;

            GameSetings.BombsQuantity = 16;
        }

        public static void Hard()
        {
            GameSetings.MapSize[0] = 15;
            GameSetings.MapSize[1] = 15;

            GameSetings.BombsQuantity = 30;
        }
    }
}
