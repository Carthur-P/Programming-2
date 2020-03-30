using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DealACard
{
    public class Card
    {
        private const int RANK = 13;
        private const int SUIT = 4;

        private PictureBox pictureBox;
        private Random rand;
        private int suit;
        private int rank;
        private string labelstring;

        public Card(PictureBox pictureBox,  Random rand)
        {
            this.rand = rand;
            this.pictureBox = pictureBox;
            labelstring = " ";
        }
        //initializing all the neccessary feild in the class

        public void DealCard()
        {
            suit = rand.Next(SUIT); 
            rank = rand.Next(RANK);
            //this will assign random numbers to the variable 'suit' and 'rank'

            switch (suit)
            {
                case 0:
                    pictureBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("C" + (rank + 1).ToString());
                    //if suit is '0' then grab the image from the recourse which starts with 'C', this will be club cards images
                    //the rank of the card is determine by the random interger value assign to the feild rank
                    //adding 1 to the rank integer is done because the image names starts at 1 eg "C1, C2"
                    //the same proccess occurs in all the cases but with a different starting letter to choose different card suit images
                    break;

                case 1:
                    pictureBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("D" + (rank + 1).ToString());
                    break;

                case 2:
                    pictureBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("H" + (rank + 1).ToString());
                    break;

                case 3:
                    pictureBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("S" + (rank + 1).ToString());
                    break;
            }
            //the switch checks what suit the card is according to the number assign to the suit
        }

        public string ChangeLabel()
        {
            switch (suit)
            {
                case 0:
                    switch (rank)
                    {
                        case 0:
                            labelstring = ("Ace of Clubs");
                            break;

                        case 10:
                            labelstring = ("Jack of Clubs");
                            break;

                        case 11:
                            labelstring = ("Queen of Clubs");
                            break;

                        case 12:
                            labelstring = ("King of Clubs");
                            break;

                        default:
                            labelstring = ((rank + 1) +  " of Clubs");
                            break;
                    }
                    break;

                case 1:
                    switch (rank)
                    {
                        case 0:
                            labelstring = ("Ace of Diamonds");
                            break;

                        case 10:
                            labelstring = ("Jack of Diamonds");
                            break;

                        case 11:
                            labelstring = ("Queen of Diamonds");
                            break;

                        case 12:
                            labelstring = ("King of Diamonds");
                            break;

                        default:
                            labelstring = ((rank + 1) + " of Diamonds");
                            break;
                    }
                    break;

                case 2:
                    switch (rank)
                    {
                        case 0:
                            labelstring = ("Ace of Hearts");
                            break;

                        case 10:
                            labelstring = ("Jack of Hearts");
                            break;

                        case 11:
                            labelstring = ("Queen of Hearts");
                            break;

                        case 12:
                            labelstring = ("King of Hearts");
                            break;

                        default:
                            labelstring = ((rank + 1) + " of Hearts");
                            break;
                    }
                    break;

                case 3:
                    switch (rank)
                    {
                        case 0:
                            labelstring = ("Ace of Spades");
                            break;

                        case 10:
                            labelstring = ("Jack of Spades");
                            break;

                        case 11:
                            labelstring = ("Queen of Spades");
                            break;

                        case 12:
                            labelstring = ("King of Spades");
                            break;

                        default:
                            labelstring = ((rank + 1) + " of Spades");
                            break;
                    }
                    break;
            } return labelstring;
            //first main switch determines what suit the card is while the embeded switch determines what rank the card is 
        }
    }
}
