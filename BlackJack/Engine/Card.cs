using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Engine
{
    internal class Card
    {
        public String Suit;
        public int Rank;

        public Card(String Suit, int Rank)
        {
            this.Suit = Suit;
            this.Rank = Rank;
        }
        public int GetBlackJackValue()
        {
            if (this.Rank > 10)
            {
                return 10;
            }
            return this.Rank;
        }

        public String GetImageFileName()
        {
            if (Rank == 1)
            {
                return  "ace_of_" + Suit + ".png";
            }

            if (Rank == 11)
            {
                return "jack_of_" + Suit + ".png";
            }

            if (Rank == 12)
            {
                return "queen_of_" + Suit + ".png";
            }

            if (Rank == 13)
            {
                return "king_of_" + Suit + ".png";
            }

            return Rank +"_of_" + Suit + ".png";
        }
    }
}
