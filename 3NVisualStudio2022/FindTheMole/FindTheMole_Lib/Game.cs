namespace FindTheMole_Lib
{
    public class Game
    {
        private bool[,] gameMatrix;

        public int GameSize
            { get; set; }

        public int NAttempt
            { get; set; }

        public bool[,] GameMatrix
            { get { return gameMatrix; } }

        public Game(int gameSize,int nAttempt, IGenerator? generator = null) 
        {
            if (gameSize < 0)
                throw new ArgumentException("illegal game size");
            if (nAttempt < 0)
                throw new ArgumentException("illegal nAttempt");

            GameSize = gameSize;
            NAttempt = nAttempt;
            gameMatrix = new bool[gameSize,gameSize];

            if (generator == null)
            {
                Generator gen = new Generator();
                gen.PlaceMole(gameMatrix);
            }
            else
            {
                generator.PlaceMole(gameMatrix);
            }


        }

        public GameStatus checkGuess(int pos1, int pos2)
        {
            if(pos1 < 0 || pos2 < 0 || pos1 > GameSize || pos2 > GameSize)
                throw new ArgumentException("illegal given pos");

            if (gameMatrix[pos1,pos2] == true)
                return GameStatus.WON;
            else if(NAttempt > 1)
                 return GameStatus.PLAYING;
            else
                return GameStatus.LOST;

        }

    }
}
