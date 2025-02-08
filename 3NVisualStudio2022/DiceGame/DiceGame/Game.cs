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

        public Game(Player p1, Player p2, int specialRoll=11, int maxRounds=15, int maxPoints=100) 
        {
            Player1 = p1;
            Player2 = p2;
            SpecialRoll = specialRoll;
            MaxRounds = maxRounds;
            MaxPoints = maxPoints;
        }

        public Player? SimulateGame(Dice GameDices)
        {
            int rounds = 1;
            int p1RolledDicePoints = Player1.Score;
            int p2RolledDicePoints = Player2.Score;

            while (rounds <= MaxRounds && p1RolledDicePoints < MaxPoints && p2RolledDicePoints < MaxPoints)
            {
                int roundPoint;
                do
                {
                    roundPoint = GameDices.RolldDiceMoreThan1Time();
                    p1RolledDicePoints += roundPoint;

                } while (roundPoint == SpecialRoll);

                do
                {
                    roundPoint = GameDices.RolldDiceMoreThan1Time();
                    p2RolledDicePoints += roundPoint;

                } while (roundPoint == SpecialRoll);

                rounds++;
            }

            if (p1RolledDicePoints > p2RolledDicePoints) return Player1;
            if (p2RolledDicePoints > p1RolledDicePoints) return Player2;
            return null;

        }

    }
}
