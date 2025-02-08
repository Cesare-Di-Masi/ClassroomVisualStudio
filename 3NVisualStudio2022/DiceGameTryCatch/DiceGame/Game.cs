using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    public class Game
    {

        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }

        private int _specialRoll;
        public int SpecialRoll 
        {
            get 
            {
                return _specialRoll;
            } 
            private set
            {
                if (value<=0) throw new ArgumentOutOfRangeException("illegal special roll");
                _specialRoll = value;
            }
        }

        private int _maxRounds;
        public int MaxRounds 
        { 
            get
            {
            return _maxRounds; 
            }
            private set 
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("illegal max rounds");
                _maxRounds = value;
            } 
        }

        private int _maxPoints;
        public int MaxPoints 
        {
            get
            {
                return _maxPoints;
            }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("illegal max points");
                _maxPoints = value;
            }
        }

        public Game(Player p1, Player p2) : this(p1, p2, 11, 15, 100) 
        {
        }

        public Game(Player p1, Player p2, int specialRoll, int maxRounds, int maxPoints) 
        {
            if (p1.Equals(p2))                
                throw new ArgumentException("illegal player for game");

            Player1 = p1;
            Player2 = p2;
            SpecialRoll = specialRoll;
            MaxRounds = maxRounds;
            MaxPoints = maxPoints;
        }

        public Player? SimulateGame(Dice GameDices)
        {
            int rounds = 1;
            

            while (rounds <= MaxRounds && Player1.Score < MaxPoints && Player2.Score < MaxPoints)
            {
                int roundPoint;
                do
                {
                    roundPoint = GameDices.RolldDiceMoreTimes(2);
                    Player1.Score += roundPoint;

                } while (roundPoint == SpecialRoll);

                do
                {
                    roundPoint = GameDices.RolldDiceMoreTimes(2);
                    Player2.Score += roundPoint;

                } while (roundPoint == SpecialRoll);

                rounds++;
            }

            if (Player1.Score > Player2.Score) 
                return Player1;
            if (Player2.Score > Player1.Score) 
                return Player2;
            return null;

        }

        internal Program Program
        {
            get => default;
            set
            {
            }
        }
    }
}
