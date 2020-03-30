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
    class Card
    {
        private Image[] image;
        private PictureBox pictureBox;

        private int suit;
        private int rank;
        private string labelstring;
        private Random rand;
        private int IMAGE = 13;
        private int RANDOM = 4;
      

        public Card(PictureBox pictureBox,  Random rand)
        {
            image = new Image[IMAGE];
            this.rand = rand;
            this.pictureBox = pictureBox;
        }

        public void ChooseACard()
        {
            suit = rand.Next(RANDOM); 
            rank = rand.Next(IMAGE);

            switch (suit)
            {
                case 0:
                    for (int i = 0, j = 1; i < image.Length; i++, j++)
                    {
                        image[i] = (Bitmap)Properties.Resources.ResourceManager.GetObject("C" + j.ToString());
                    }
                    break;

                case 1:
                    for (int i = 0, j = 1; i < image.Length; i++, j++)
                    {
                        image[i] = (Bitmap)Properties.Resources.ResourceManager.GetObject("D" + j.ToString());
                    }
                    break;

                case 2:
                    for (int i = 0, j = 1; i < image.Length; i++, j++)
                    {
                        image[i] = (Bitmap)Properties.Resources.ResourceManager.GetObject("H" + j.ToString());
                    }
                    break;

                case 3:
                    for (int i = 0, j = 1; i < image.Length; i++, j++)
                    {
                        image[i] = (Bitmap)Properties.Resources.ResourceManager.GetObject("S" + j.ToString());
                    }
                    break;

            }//end of switch loop for suit

        }//end of ChooseACard method

        public void LoadPictureBox ()
        {
            pictureBox.Image = image[rank];
        }//end of LoadPictureBox method

        public string ChangeLabel()
        {
            labelstring = " ";
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

                    }//end of switch statement for rank
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

                    }//end of switch statement for rank
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

                    }//end of switch statement for rank
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

                    }//end of switch statement for rank
                    break;
            }
            return labelstring;//end of rank switch statement for suit

        }//end of ChangeLabel method
    }
}
