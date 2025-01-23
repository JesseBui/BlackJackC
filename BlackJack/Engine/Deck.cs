using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Engine
{
    internal class Deck
    {
        List<Card> cards = new List<Card>();

        public void Innit()
        {
            List<string> suits = new List<string> { "Hearts", "Diamonds", "Spades", "Clubs" };
            foreach (string suit in suits)
            {
                for (int i = 1; i < 14; i++)
                {
                    Card c = new Card(suit, i);
                    cards.Add(c);
                }
            }
        }

        public void Shuffle()
        {
            Random r = new Random();
            for (int i = 0; i < 53; i++)
            {
                int index1 = r.Next(cards.Count);
                int index2 = r.Next(cards.Count);
                Card temp = cards[index1];
                cards[index1] = cards[index2];
                cards[index2] = temp;
            }
        }

        public Card GetCard()
        {
            Card c = cards[0];

            cards.Remove(c);
            return c;
        }
    }
}
