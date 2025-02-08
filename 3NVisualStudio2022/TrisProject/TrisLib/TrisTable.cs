using System.Numerics;

namespace TrisLib
{
    public class TrisTable
    {
        public bool?[,] Matrix = new bool?[3, 3];
        public bool BotIsOn { get; private set; }

        public TrisTable(bool botIsOn = false) 
        {
            BotIsOn = botIsOn;
        }

        public bool makeATurn(int coordX, int coordY, bool isX = true)
        {
            if (coordX < 1 || coordX > 3) { throw new ArgumentOutOfRangeException("illegal X coord"); }
            if (coordY < 1 || coordY > 3) { throw new ArgumentOutOfRangeException("illegal Y coord"); }
            if (Matrix[coordY-1, coordX-1] != null) { throw new ArgumentNullException("illegal coord selected, already occupied"); }

            if (isX == true)
            {
                Matrix[coordY-1, coordX-1] = true;

            }
            else
            {
                Matrix[coordY-1, coordX-1] = false;
            }
            string player;
            if (isX) player = "X"; else player = "O";
            if (CheckWin(isX)) return true; else return false;

        }



        private string Converter(int y, int x)
        {

            if (Matrix[y, x] == null)
            {
                return " ";
            }
            else if (Matrix[y, x] == true)
            {

                return "X";
            }
            else
            {

                return "O";
            }
        }


        public override string ToString()
        {
            string stringone;
            stringone =
            ("   1  |  2  |  3  \n") +
            ("      |     |     \n") +
            ($"1  {Converter(0, 0)}  |  {Converter(0, 1)}  |  {Converter(0, 2)}  \n")  +
            ("______|_____|_____\n") +
            ("      |     |     \n") +
            ($"2  {Converter(1, 0)}  |  {Converter(1, 1)}  |  {Converter(1, 2)}  \n")  +
            ("______|_____|_____\n") +
            ("      |     |     \n") +
            ($"3  {Converter(2, 0)}  |  {Converter(2, 1)}  |  {Converter(2, 2)}  \n")  +
            ("      |     |     ");
            return stringone;
        }






        private bool CheckWin(bool player)
        {
            bool? firstBox = null;
            bool secondBox = false;
            

            for (int i = 0; i < 3; i++)
            {
                firstBox = Matrix[i,0];
                for (int j = 0; j < 3; j++)
                {
                    if (firstBox == Matrix[i, j] && firstBox!=null) 
                    {
                        secondBox = true;
                    }

                    if (firstBox == Matrix[i, j] && secondBox)
                        return true;
                    

                }

            }

            secondBox = false;
            for (int i = 0; i < 3; i++)
            {
                firstBox = Matrix[0, i];
                for (int j = 0; j < 3; j++)
                {
                    if (firstBox == Matrix[j, i] && firstBox != null)
                    {
                        secondBox = true;
                    }

                    if (firstBox == Matrix[j, i] && secondBox)
                        return true;
                }

            }

            if ((Matrix[0, 0] == Matrix[1, 1] == Matrix[2, 2]) && Matrix[0,0] == player||
                (Matrix[2, 0] == Matrix[1, 1] == Matrix[0, 2]) && Matrix[2,0] == player) 
            {
                return true;
            }
                  
            return false;

        }






    }
}
/*
 * int[][,] winningCombinations =
            {
                new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 } },
                new int[,] { { 1, 0 }, { 1, 1 }, { 1, 2 } },
                new int[,] { { 2, 0 }, { 2, 1 }, { 2, 2 } },
                new int[,] { { 0, 0 }, { 1, 0 }, { 2, 0 } },
                new int[,] { { 0, 1 }, { 1, 1 }, { 2, 1 } },
                new int[,] { { 0, 2 }, { 1, 2 }, { 2, 2 } },
                new int[,] { { 0, 0 }, { 1, 1 }, { 2, 2 } },
                new int[,] { { 2, 0 }, { 1, 1 }, { 0, 2 } }
            };

            foreach (var combination in winningCombinations)
            {
                if (Matrix[combination[0, 0], combination[0, 1]] == player &&
                    Matrix[combination[1, 0], combination[1, 1]] == player &&
                    Matrix[combination[2, 0], combination[2, 1]] == player)
                {
                    return true;
                }
            }

            return false;
    }
 * */