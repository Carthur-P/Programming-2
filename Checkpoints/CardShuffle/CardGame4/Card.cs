//individual cards, this sets up what image of card to use depending on the the suits and ranks

using System.Drawing;

namespace CardGame4
{
    public class Card
    {
        private Image image;
        private eSuits suit;
        private eRanks rank;

        public Card(eSuits suit, eRanks rank)//constructor
        {
            this.suit = suit;
            this.rank = rank;
            image = (Bitmap)Properties.Resources.ResourceManager.GetObject(rank.ToString() + suit.ToString());
        }

        public override string ToString()//override makes this method override the ToString method that already excist
        {
            return ((rank.ToString()) + " of " + (suit.ToString()));
        }

        public Image Image
        {
            get
            {
                return image;
            }
        }
    }
}
