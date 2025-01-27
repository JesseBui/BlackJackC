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
        public int PlayerChips { get; private set; }
        public int CurrentBet { get; private set; }

        public BjEngine()
        {
            PlayerChips = 1000;
            deck.Innit();
            deck.Shuffle(); 
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

        public void DealerPlay()
        {
            while (GetDealerScore() < 17)
            {
                DealToDealer();
            }
        }
        public void Stand()
        {
            DealerPlay();
        }

        public void IncreaseBet()
        {
            CurrentBet += 10;
            PlayerChips -= 10;
        }

        public void DecreaseBet()
        {
            if (CurrentBet > 0)
            {
                CurrentBet -= 10;
                PlayerChips += 10;
            }
        }

        public void PlayerWin()
        {
            PlayerChips += CurrentBet * 2;
            CurrentBet = 0;
        }

        public void Playerlose()
        {
            PlayerChips -= CurrentBet;
            CurrentBet = 0;
        }

        public void PlaceBet(int bet)
        {
            if (bet > PlayerChips)
            {
                throw new InvalidOperationException("Bet exceeds player's available chips.");
            }
            PlayerChips -= bet;
            CurrentBet = bet;
        }

        public void NewGame()
        {
            ResetPlayerScore();
            ResetDealerScore();
            PlayerChips = 1000;
            CurrentBet = 0;
            deck.Shuffle();
            Start();
        }
    }
}
    

