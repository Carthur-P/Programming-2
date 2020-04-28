using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2
{
    public class Deck
    {
        private const int SUITS = 4;
        private const int RANK = 13;
        private const int CARDS = 52;

        private Random rand;
        private List<Card> cards;

        public Deck(Random rand)
        {
            cards = new List<Card>();
            this.rand = rand;

            for (int i = 0; i < SUITS; i++)
            {
                for (int j = 0; j < RANK; j++)
                {
                    cards.Add(new Card((eSuits)i, (eRanks)j));
                }
            }
        }

        public Card DealACard()
        {
            int randomCard = rand.Next(CARDS);
            return cards[randomCard];
        }
    }
}
