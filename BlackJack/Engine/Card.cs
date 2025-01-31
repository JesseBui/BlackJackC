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
        public bool FaceUp { get; set; }
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
            } else if (this.Rank == 1)
            {
                return 11;
            }
            return this.Rank;
        }

        public String GetImageFileName()
        {
            if (this.FaceUp == false)
            {
                if (Rank == 1)
                {
                    return "ace_of_" + Suit + ".png";
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

                return Rank + "_of_" + Suit + ".png";
            }
            else
            {
                return "back.png";
            }
        }
    }
}
