using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheMole_Lib
{
    public class FixedGenerator:IGenerator
    {
        public void PlaceMole(bool[,] gameMatrix)
        {
            gameMatrix[0, 0] = true;
        }
    }
}
