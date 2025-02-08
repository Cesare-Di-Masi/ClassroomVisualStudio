using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrisLib
{
    internal class TrisBotNormal
    {
        public List<int> AvailableNumbers = new List<int> {1,2,3,4,5,6,7,8,9};

        private bool _firstTime = true;

        public bool Player { get; private set; }
        private bool?[,] _matrix { get; set; }

        public bool?[,] Matrix 
        {
            get {return _matrix; }
            private set 
            {
                
            }
        }

        private bool?[] _trisTable = new bool?[9];

        public bool?[] TrisTable
        {
            get { return _trisTable; }

            set
            {
                int counter = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Matrix[i, j] != value[counter] && _firstTime == true)
                        {
                            value[counter] = Matrix[i, j];

                        }
                        else if (Matrix[i, j] != value[counter] && _firstTime == false)
                        {
                            value[counter] = Matrix[i, j];
                            break;
                        }
                        counter++;
                    }
                }
                _trisTable = value;
            }
        }



        public TrisBotNormal(bool?[,] matrix, bool player) 
        {
            Matrix = matrix;
            Player = player;
        }


        public (int riga, int colonna) BotMakesAMove()
        {
            int n=0;
            bool exitLoop = false;
            while (exitLoop == false) 
            {
                Random rand = new Random();
                n = rand.Next(AvailableNumbers.Count);
                if (TrisTable[AvailableNumbers[n]-1] == null) 
                {
                    TrisTable[AvailableNumbers[n] - 1] = Player;
                    exitLoop = true;
                }else
                {
                    AvailableNumbers.Remove(n);
                }
            }

            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (counter == n-1)
                    {
                        return (i, j);
                    }
                    counter++;
                }
            }

            return (0 , 0);
           

        }

        

    }
}
