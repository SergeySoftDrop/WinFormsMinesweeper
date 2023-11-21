using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сапёр3.Setings
{
    static class GameSetings
    {
        private static int cellSize = 50;
        public static int CellSize
        {
            get { return cellSize; }
            set 
            {
                if (value > 0 && value <= 80)
                    cellSize = value;
            }
        }

        private static int[] mapSize = {9,9};
        public static int[] MapSize
        {
            get { return mapSize; }
            set 
            {
                if (value[0] >= 0 && value[0] <= 15)
                    mapSize[0] = value[0];
                if (value[1] > 0 && value[1] <= 15)
                    mapSize[1] = value[1];
            }
        }        

        private static int bombsQuantity = 5;
        public static int BombsQuantity
        {
            get { return bombsQuantity; }
            set 
            {
                if (value > 0 && Math.Abs((mapSize[0] * mapSize[1]) / value) >= 4)
                {
                    bombsQuantity = value;
                }
            }
        }
    }
}
