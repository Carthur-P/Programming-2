using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2
{
    public class Card
    {
        private Image image;
        private eSuits suit;
        private eRanks rank;

        public Card(eSuits suit, eRanks rank)
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
