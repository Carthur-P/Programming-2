using System;
using System.Collections.Generic;
//creates a list of five cards simulating a hand of cards which will be shown in the form

namespace CardGame4
{
    public class Hand
    {
        private List<Card> fiveCards;
        private Deck deck;

        public Hand(Random rand)//constructor
        {
            fiveCards = new List<Card>();
            deck = new Deck(rand);
        }

        public void DealAHand()//getting the first five cards of the deck and storing it in a list called hand
        {
            fiveCards = deck.DealAHand();
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
