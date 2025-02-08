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
            if (CheckWin(isX)) return true; 
            else return false;

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

        private bool CheckWin(bool player)
        {
            //faccio un array comprensivo di tutte le combinazioni possibili
            int[][,] winningCombinations =
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

            //ciclo le combinazione
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


        public override string ToString()
        {
            //stampa della tabella
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
    }
}
/*
 * public Player CheckWin(bool currentPlayer)
    {
        int[][] winningCombinations = new int[][]
        {
            new int[] {0, 1, 2}, // Riga 1
            new int[] {3, 4, 5}, // Riga 2
            new int[] {6, 7, 8}, // Riga 3
            new int[] {0, 3, 6}, // Colonna 1
            new int[] {1, 4, 7}, // Colonna 2
            new int[] {2, 5, 8}, // Colonna 3
            new int[] {0, 4, 8}, // Diagonale principale
            new int[] {2, 4, 6}  // Diagonale secondaria
        };

        foreach (var combination in winningCombinations)
        {
            if (board[combination[0]] == currentPlayer &&
                board[combination[1]] == currentPlayer &&
                board[combination[2]] == currentPlayer)
            {
                return currentPlayer;
            }
        }

        return Player.None;
    }
 * */