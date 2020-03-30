//creating a list of 52 of different cards simulating a deck of cards

using System;
using System.Collections.Generic;

namespace CardGame4
{
    public class Deck
    {
        private const int SUITS = 4;
        private const int RANK = 13;
        private const int CARDS = 52;
        private const int SHUFFLE = 40;

        private Random rand;
        private List<Card> cards;

        public Deck(Random rand)//constructor
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

        private void Shuffle()//picking two cards out of the list and swapping their places
        {
            int card1 = rand.Next(cards.Count);
            int card2 = rand.Next(cards.Count);
            Card temp = cards[card1];
            cards[card1] = cards[card2];
            cards[card2] = temp;
        }

        public List<Card> DealAHand()//populating a list of five cards that is going to be a hand of cards
        {
            List<Card> hand;
            hand = new List<Card>();

            for (int i = 0; i <= SHUFFLE; i++)
            {
                Shuffle();
            }

            for (int i = 0; i <= 5; i++)
            {
                hand.Add(cards[i]);
            }

            return hand;
        }
    }
}
