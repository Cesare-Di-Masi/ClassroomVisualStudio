using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibVERIFICA_APRILE_DIMASI
{
    public class Generator:IGenerator//questo è il generatore random
    {

        public void hideTreasure(bool[,] grid)
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random();

            grid[rnd1.Next(0, grid.GetLength(0)), rnd2.Next(0, grid.GetLength(1))] = true;

        }

    }
}
