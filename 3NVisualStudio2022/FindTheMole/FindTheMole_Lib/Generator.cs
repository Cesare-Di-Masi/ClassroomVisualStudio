using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheMole_Lib
{
    public class Generator:IGenerator
    {
        public void PlaceMole(bool[,] gameMatrix)
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random();

            gameMatrix[rnd1.Next(0, gameMatrix.GetLength(0)), rnd2.Next(0, gameMatrix.GetLength(1))] = true;
        }
    }
    
}
