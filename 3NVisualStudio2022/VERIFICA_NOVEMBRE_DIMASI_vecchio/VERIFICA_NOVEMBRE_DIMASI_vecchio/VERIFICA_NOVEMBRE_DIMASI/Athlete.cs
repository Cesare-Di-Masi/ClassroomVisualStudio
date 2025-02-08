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

        //Creato questo metodo così non andrò a riscrivere (return session.Minutes + session.Hours * 60;) più volte
        private int getMinutes(Session session)
        {
            return session.Minutes + session.Hours * 60;
        }

        public int getBestIntensiveSessionMinutes()
        {
            return getMinutes(BestIntensive);
        }

        public int getBestStandardSessionMinutes()
        {
            return getMinutes(BestStandard);
        }

        public void IsNewSessionBetter(Session newSession)
        {
            //controllo se il tipo dell'allenamento sia intensivo o no
            if (newSession.IsIntensive)
            {
                if (getMinutes(newSession) + newSession.Seconds > getBestIntensiveSessionMinutes() + BestIntensive.Seconds)
                {
                    BestIntensive = newSession;
                }
            }
            else
            {
                if (getMinutes(newSession) + newSession.Seconds > getBestStandardSessionMinutes() + BestStandard.Seconds)
                {
                    BestStandard = newSession;
                }
            }

        }


    }
}
