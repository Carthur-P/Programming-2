/* Program name:          CardShuffle
 * Project file name:     Card Shuffle
 * Author:                Carthur Pongpatimet
 * Date:                  26/08/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To generate a hand of five cards each time a button is clicked
 * 
 * Description:           Hand - The hand class holds a list of five cards which is given from the deck class,
 *                        these five cards are displayed onto the form when the button is clicked
 *                        
 *                        Deck - contains a list of 52 cards which is shuffled everytime the button is clicked,
 *                        the first five cards from the list is then given to the hand class
 *                        
 *                        Card - This is the individual cards and contains the image of a card base on the rank
 *                        and suit that was given to it
 *                        
 * Known bugs:            None
 * Additional features:   None
 */

using System;
using System.Windows.Forms;

namespace CardGame4
{
    public partial class Form1 : Form
    {
        private const int TWO = 2;
        private const int THREE = 3;
        private const int FOUR = 4;

        private Hand hand;
        private Random rand;
        public Form1()//constructor
        {
            InitializeComponent();
            rand = new Random();
            hand = new Hand(rand);
        }

        private void button1_Click(object sender, EventArgs e)//when deal a hand button is clicked
        {
            hand.DealAHand();
            pictureBox1.Image = hand.FiveCards[0].Image;
            pictureBox2.Image = hand.FiveCards[1].Image;
            pictureBox3.Image = hand.FiveCards[TWO].Image;
            pictureBox4.Image = hand.FiveCards[THREE].Image;
            pictureBox5.Image = hand.FiveCards[FOUR].Image;
            textBox1.Text = hand.FiveCards[0].ToString().ToLower();
            textBox2.Text = hand.FiveCards[1].ToString().ToLower();
            textBox3.Text = hand.FiveCards[TWO].ToString().ToLower();
            textBox4.Text = hand.FiveCards[THREE].ToString().ToLower();
            textBox5.Text = hand.FiveCards[FOUR].ToString().ToLower();
        }
    }
}
