namespace FindTheMole_Lib
{
    public class Game
    {
        private bool[,] _gameMatrix;

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
            _gameMatrix = new bool[gameSize,gameSize];

<<<<<<< HEAD
            Random rnd1 = new Random();
            Random rnd2 = new Random();

            _gameMatrix[rnd1.Next(0, gameSize), rnd2.Next(0, gameSize)] = true;
=======
            if (generator == null)
            {
                Generator gen = new Generator();
                gen.PlaceMole(gameMatrix);
            }
            else
            {
                generator.PlaceMole(gameMatrix);
            }
>>>>>>> 5e03fa9a0c358bf8c6d5ae6711ef112c436f7847


        }

<<<<<<< HEAD
        public Game(int gameSize,int nAttempt,int molePos1,int molePos2) : this(gameSize, nAttempt) 
        {
            _gameMatrix = new bool[gameSize,gameSize];
            _gameMatrix[molePos1,molePos2] = true;
        }

        public bool checkGuess(int pos1, int pos2)
=======
        public GameStatus checkGuess(int pos1, int pos2)
>>>>>>> 5e03fa9a0c358bf8c6d5ae6711ef112c436f7847
        {
            if(pos1 < 0 || pos2 < 0 || pos1 > GameSize || pos2 > GameSize)
                throw new ArgumentException("illegal given pos");

<<<<<<< HEAD
            if (_gameMatrix[pos1,pos2] == true)
                return true;
            return false;
=======
            if (gameMatrix[pos1,pos2] == true)
                return GameStatus.WON;
            else if(NAttempt > 1)
                 return GameStatus.PLAYING;
            else
                return GameStatus.LOST;
>>>>>>> 5e03fa9a0c358bf8c6d5ae6711ef112c436f7847

        }

    }
}
