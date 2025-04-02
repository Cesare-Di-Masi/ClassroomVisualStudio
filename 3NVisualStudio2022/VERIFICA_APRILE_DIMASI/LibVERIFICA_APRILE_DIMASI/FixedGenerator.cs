using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibVERIFICA_APRILE_DIMASI
{
    public class FixedGenerator:IGenerator//questo generatore posizionerà il tesoro sempre nella posizione 0,0
    {
        public void hideTreasure(bool[,] grid)
        {
            grid[0, 0] = true;
        }
    }
}
