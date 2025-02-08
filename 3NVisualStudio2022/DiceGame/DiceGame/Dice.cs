using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DiceGame
{
    public class Dice
    {

        int _nFaces;
        public int NFaces 
        { 
            get
            {
                return _nFaces;
            }
            private set 
            {
                if (value < 4 || value%2 == 1) { throw new ArgumentOutOfRangeException("illegal dice");}
                _nFaces = value;
            }
        }

        public Dice(int nFace = 6)
        {        
            NFaces = nFace;
        }

        public int RollDice()
        {
            int result = new Random().Next(0, NFaces);
            return result;
        }

        public int RolldDiceMoreThan1Time(int times = 2)
        {
            int result=0;
            for (int i = 0; i < times; i++)
            {
                result += new Random().Next(times, NFaces);
            }
            return result;
        }
    }
}
