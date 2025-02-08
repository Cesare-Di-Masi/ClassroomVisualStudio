using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libSUPERFIGHT
{
    public class Game
    {

        public bool[] SelectedDecks 
        { 
            get; 
            set; 
        }

        public Game(bool[] selectedDecks)
        {
            SelectedDecks = selectedDecks;
        }

        public string[] drawFighters()
        {
            int counter = 0;
            for (int i = 0; i < SelectedDecks.Length; i++)
            {
                if (SelectedDecks[i])
                    counter++;
            }

            string[] fighters = new string[counter];

            Random rnd = new Random();

            BaseDeckFighters BaseDeckFighters = new B;

            fighters[0] = BaseDeckFighters[rnd.Next(0, sizeof(BaseDeckFighters))];


        }

    }
}
