using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DiceGame
{
    public class Player
    {
        string _nickname;
        public string Nickname 
        {

            get 
            {
                return _nickname;
            }
            private set
            {
                if (value == null) throw new ArgumentException("illegal nickname");
                _nickname = value;
            }
        }

        private int _score;
        public int Score 
        {
            get
            {
                return _score;
            }
            private set
            {
                if (value<0) throw new ArgumentOutOfRangeException("illegal score");
                _score= value;
            }
        }

        public Player(string nickname) : this(nickname,0)
        { 
        }

        public Player(string nickname, int score)
        {
            Score = score;
            Nickname = nickname;
        }


        public override string ToString() 
        {
            return Nickname;
        }

        public override bool Equals(object? obj)
        {
            
            if (obj == null) return false;
            
            if (obj is Player == false) return false;

            
            Player player = obj as Player; 
            if (Nickname == player.Nickname && Score == player.Score) return true;
            return false;
        }


    }
}
