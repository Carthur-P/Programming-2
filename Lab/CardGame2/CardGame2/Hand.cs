using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2
{
    public class Hand
    {
        private const int HAND = 5;

        private List<Card> fiveCards;
        private Deck deck;

        public Hand(Random rand)
        {
            fiveCards = new List<Card>();
            deck = new Deck(rand);
        }

        public void DealAHand()
        {
            for (int i = 0; i < HAND; i++)
            {
                fiveCards.Add(deck.DealACard());
            }
        }

        public List<Card> FiveCards
        {
            get
            {
                return fiveCards;
            }
        }
    }
}
