using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatistisDiceLib
{
    public class Dice
    {
        private int _nFaces;
        public int NFaces
        { 
            get
            {
                return _nFaces; 
            }

            private set
            {
                if (value % 2 != 0 && value <= 4) { throw new ArgumentOutOfRangeException("illegal number of faces"); }
                _nFaces = value;
            }
        }

        public Dice(int nFaces=6)
        {
            NFaces = nFaces;
        }

        public int throwDice()
        {
            Random rnd = new Random();
            return rnd.Next(1,NFaces+1);
        }




    }
}
