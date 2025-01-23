using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Engine
{
    internal class BjEngine
    {
        Deck deck = new Deck();
        public List<Card> dealerCards = new List<Card>();
        public List<Card> playerCards = new List<Card>();
        public BjEngine()
        {
            deck.Innit();
            deck.Shuffle(); //NO
        }

        public List<Card> getDealerCard()
        {
            return dealerCards;
        }
        public List<Card> getPlayerCard()
        {
            return playerCards;
        }

        public void DealToDealer()
        {
            Card c = deck.GetCard();
            dealerCards.Add(c);
        }
        public Card DealToPlayer()
        {
            Card c = deck.GetCard();
            playerCards.Add(c);
            return c;
        }

        public bool Hit()
        {
            Card c = DealToPlayer();
            if (GetPlayerScore() > 21)
            {
                return false;
            }
            return true;
        }

        public int GetPlayerScore()
        {
            int score = 0;
            foreach (Card c in playerCards)
            {
                score += c.GetBlackJackValue();
            }
            return score;
        }

        public int GetDealerScore()
        {
            int score = 0;
            foreach (Card c in dealerCards)
            {
                score += c.GetBlackJackValue();
            }
            return score;
        }

        public void ResetPlayerScore()
        {
            playerCards.Clear();
        }

        public void ResetDealerScore()
        {
            dealerCards.Clear();
        }

        public void Start()
        {
            DealToDealer();
            DealToPlayer();
            DealToDealer();
            DealToPlayer();
        }
    }
}
