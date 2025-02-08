using LibraryProject;

namespace CoreLibrary
{
    public enum GameStatus
    {
        LOSE,
        WIN,
        IN_PROGRESS
    }
    public class Game
    {
        private int _maxAttempts;
        private int _usedAttempts;

        private int _numberToGuess;
        private GameStatus _status;
        public GameStatus Status { get { return _status; } }

        private IGenerator _generator;

        private List<int> _allAttempts;
        public List<int> AllAttempts { get { return _allAttempts; } }
        public int RemainingAttempts
        {
            get { return _maxAttempts - _usedAttempts; }
        }

        public Game(int maxAttempts=10, int maxNumber=1000, IGenerator? generator=null)
        {
            this._maxAttempts = maxAttempts;
            this._usedAttempts = 0;
            _allAttempts = new List<int>();

            if(generator == null ) { _generator = new RandomGenerator(); }
            else { _generator = generator; }

            this._numberToGuess = _generator.GenerateNumber(maxNumber);

            _status = GameStatus.IN_PROGRESS;
        }

        public GameStatus Attempts(int attempts)
        {
            _usedAttempts += 1;
            _allAttempts.Add(attempts);

            if (attempts == _numberToGuess)
            {
                _status = GameStatus.WIN;
            }
            else
            {
                if (RemainingAttempts > 0)
                    _status = GameStatus.IN_PROGRESS;
                else
                    _status = GameStatus.LOSE;
            }

            return Status;
        }

    }
}
