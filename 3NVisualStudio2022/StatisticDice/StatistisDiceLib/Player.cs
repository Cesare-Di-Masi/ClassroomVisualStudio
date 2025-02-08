using System.Security.Cryptography.X509Certificates;

namespace StatistisDiceLib
{
    public class Player
    {
        private Dice _usedDice;

        private string _name;
        private int _nGame;
        private int[] _throwList;

        public int[] countOfNumber;


        public string Name 
        {
            get
            {
                return _name; 
            }

            private set
            {
                if(String.IsNullOrEmpty(value)) { throw new ArgumentNullException("illegal name"); }
                _name = value;
            }
        }

        public Dice UsedDice
        {
            get
            {
                return _usedDice;
            }
            private set
            {
                _usedDice = value;
            }
        }

        public int[] ThrowList
        {
            get
            {  
                return _throwList;
            }
            private set
            {  
                _throwList = value; 
            }
        }

        public bool isMadeUp()
        {       
            for (int i = 0; i < countOfNumber.Length; i++)
            {
                if (countOfNumber[i] > ThrowList.Length / 2)
                    return true;
            }
            return false;                      
        }

        public Player(string name, Dice usedDice, int[] score):this(score)
        {
            Name = name;
            UsedDice = usedDice;
            countOfNumber = new int[usedDice.NFaces];
        }

        public Player(int[] score)
        {
            ThrowList = score;
            UsedDice = new Dice(6);
            countOfNumber = new int[6];
        }

        public void PlayGames()
        {
            for (int i = 0; i < ThrowList.Length; i++)
            {
                int number = UsedDice.throwDice();
                ThrowList[i] = number;
                countOfNumber[number-1]++;
            }
        }

        public int CalculateTotScore()
        {
            int score = 0, counter = 0;

            foreach (int number in ThrowList)
            {
                score += number;
                if(number == countOfNumber.Length)
                    counter++;
            }

            return score*counter;
        }

        public int getNTimesANumberIsReceived(int number)
        {
            if (number < 1 || number > countOfNumber.Length) { throw new ArgumentOutOfRangeException("illegal requested number get N times"); }

            return countOfNumber[number-1];
        }

        public int[] WhichThrowANumberIsReceived(int number)
        {
            if (number < 1 || number > countOfNumber.Length) { throw new ArgumentOutOfRangeException("illegal requested number which throw a number"); }

            int[] times = new int[countOfNumber[number-1]];

            int counter = 0;

            for (int i = 0;i < ThrowList.Length;i++)
            {
                if (ThrowList[i] == number)
                {
                    times[counter] = ThrowList[i];
                    counter++;
                }
            }

            return times;
            
        }


        public int FrequenceOfANumber(int number)
        {
            if (number < 1 || number > countOfNumber.Length) { throw new ArgumentOutOfRangeException("illegal requested number"); }

            return (countOfNumber[number-1]/ ThrowList.Length) *100;
        }

        public bool AreParametersTheSame(Player player)
        {
            if (UsedDice.NFaces == player.UsedDice.NFaces && ThrowList.Length == player.ThrowList.Length)
                return true; 
            return false;
        }

    }

}
