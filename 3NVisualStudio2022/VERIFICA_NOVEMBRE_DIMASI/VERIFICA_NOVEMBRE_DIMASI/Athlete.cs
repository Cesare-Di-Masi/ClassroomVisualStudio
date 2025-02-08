using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VERIFICA_NOVEMBRE_DIMASI
{
    public class Athlete
    {
        private int _cardNumber;
        private string _name;
        private Session _bestIntensive, _bestStandard;

        public int CardNumber
        {
            get
            {
                return _cardNumber;
            }

            private set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException("Illegal card number"); }

                _cardNumber = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            private set
            {
                //se il nome è vuoto ("") o blank (" ") dai un errore.
                if (String.IsNullOrWhiteSpace(value)) { throw new ArgumentOutOfRangeException("Illegal name"); }

                _name = value;
            }
        }

        public Session BestIntensive
        {
            get
            {
                return _bestIntensive;
            }

            private set
            {
                if (value.IsIntensive == false) { throw new ArgumentOutOfRangeException("Illegal Best intensive training"); }

                _bestIntensive = value;
            }
        }

        public Session BestStandard
        {
            get
            {
                return _bestStandard;
            }

            private set
            {
                if (value.IsIntensive == true) { throw new ArgumentOutOfRangeException("Illegal Best standard training"); }

                _bestStandard = value;
            }
        }



        public Athlete(int cardNumber, string name, Session bestIntensive, Session bestStandard)
        {
            CardNumber = cardNumber;
            Name = name;
            BestIntensive = bestIntensive;
            BestStandard = bestStandard;

        }
        

        public int getBestIntensiveSessionMinutes()
        {
            return BestIntensive.getMinutes();
        }

        public int getBestStandardSessionMinutes()
        {
            return BestStandard.getMinutes();
        }

        public void IsNewSessionBetter(Session newSession)
        {
            //controllo se il tipo dell'allenamento sia intensivo o no
            if (newSession.IsIntensive)
            {
                if (newSession.getSeconds()  > BestIntensive.getSeconds())
                {
                    BestIntensive = newSession;
                }
            }
            else
            {
                if ( newSession.getSeconds() > BestStandard.getSeconds())
                {
                    BestStandard = newSession;
                }
            }

        }


    }
}
