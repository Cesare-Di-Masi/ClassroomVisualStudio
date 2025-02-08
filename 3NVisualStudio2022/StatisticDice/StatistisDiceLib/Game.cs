using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StatistisDiceLib
{
    public class Game
    {
        public enum WhoIsTheWinner
        {
            Player1, Player2, NONE, Tie
        }

        private Player _p1, _p2;
        private Dice _usedDice;

        public Player P1 
        {
            get;
            private set;
        }

        public Player P2
        {
            get;
            private set;
        }



        public Game(Player p1, Player p2) 
        {
            if (p1.AreParametersTheSame(p2) == false)
                throw new ArgumentOutOfRangeException("illegal Player Games. Must be Equal for both");
            P1 = p1;
            P2 = p2;
            _usedDice = p1.UsedDice;
        }

        public void Play()
        {
            P1.PlayGames();
            P2.PlayGames();
        }

        public WhoIsTheWinner Winner()
        {
            if (P1.isMadeUp() == false || P2.isMadeUp() == false)
            {
                if (P1.CalculateTotScore() > P2.CalculateTotScore())
                {
                    return WhoIsTheWinner.Player1;
                }
                else if (P1.CalculateTotScore() < P2.CalculateTotScore())
                {
                    return WhoIsTheWinner.Player2;
                }
                else
                {
                    return WhoIsTheWinner.Tie;
                }
            }
            else
            {
                return WhoIsTheWinner.NONE;
            }
            

        }

        public int TotFrequence(int number)
        {
            if (number < 0 || number > P1.UsedDice.NFaces)
                throw new ArgumentOutOfRangeException("illegal number for tot frequence");

            return (P1.countOfNumber[number-1]+P2.countOfNumber[number-1]) * 100 / (P1.ThrowList.Length*2);
        }

        public int[] TotInWhichThrowANumberIsReceived(int number)
        {
            if (number < 1 || number > _usedDice.NFaces) { throw new ArgumentOutOfRangeException("illegal requested number which throw a number"); }
            int[] gameList = new int[P1.countOfNumber[number-1] + P2.countOfNumber[number-1]];
            int[] p1List = P1.WhichThrowANumberIsReceived(number - 1);
            int[] p2List = P2.WhichThrowANumberIsReceived(number - 1);
            int counter = 0;


            for (int i = 0; i < P1.countOfNumber[number - 1]; i++)
            {
                gameList[i] = p1List[i];
                counter ++;
            }

            for (int i = 0; i < P2.countOfNumber.Length; i++)
            {
                gameList[i+counter] = p1List[i];
            }

            return gameList;
            
        }



    }
}
