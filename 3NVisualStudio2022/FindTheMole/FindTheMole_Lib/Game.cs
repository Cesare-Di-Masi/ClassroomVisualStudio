namespace FindTheMole_Lib
{
    public class Game
    {
        private bool[,] gameMatrix;

        public int GameSize
            { get; set; }

        public int NAttempt
            { get; set; }

        public Game(int gameSize,int nAttempt) 
        {
            if (gameSize < 0)
                throw new ArgumentException("illegal game size");
            if (nAttempt < 0)
                throw new ArgumentException("illegal nAttempt");

            GameSize = gameSize;
            NAttempt = nAttempt;
            gameMatrix = new bool[gameSize,gameSize];

            Random rnd1 = new Random();
            Random rnd2 = new Random();

            gameMatrix[rnd1.Next(0, gameSize), rnd2.Next(0, gameSize)] = true;


        }

        public bool checkGuess(int pos1, int pos2)
        {
            if(pos1 < 0 || pos2 < 0)
                throw new ArgumentException("illegal given pos");

            if (gameMatrix[pos1,pos2] == true)
                return true;
            return false;

        }

    }
}
