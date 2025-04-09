using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibVERIFICA_APRILE_DIMASI
{
    public class Player
    {
        private string _name;
        private int _currentAttempt;

        public string Name
            { get { return _name; } }

        public int CurrentAttempt
            { get { return _currentAttempt; } }

        public Player(string name)
        {
            _name = name;
        }

        public void makeAnAttempt()//il counter dei tentativi eseguiti aumenta
        {
            _currentAttempt++;
        }

    }
}
