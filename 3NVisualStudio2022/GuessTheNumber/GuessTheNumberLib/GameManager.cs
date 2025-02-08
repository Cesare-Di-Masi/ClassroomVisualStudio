namespace GuessTheNumberLib
{
    public class GameManager
    {
        private int _nMax;
        private int _maxAttempts;
        private int _numberToGuess;
        private int _attemptsDone = 0;

        public GameManager(int attempts, int maxNumber)
        {
            if (attempts <= 0)
                throw new ArgumentOutOfRangeException("attempts must be more than 0");

            if (maxNumber <= 1)
                throw new ArgumentOutOfRangeException("max number must be at least 2");

            _maxAttempts = attempts;
            _nMax = maxNumber;
            Random _rnd = new Random();
            _numberToGuess = _rnd.Next(1, maxNumber + 1);
        }

        public int RemainingAttempts
        {
            get { return _maxAttempts - _attemptsDone; }
        }

        public Result TryToGuess(int number)
        {
            if (number == _numberToGuess)
                return Result.Win;
            else if (RemainingAttempts == 1)
                return Result.Lose;

            _attemptsDone++;
            return Result.InProgress;
        }
    }
}