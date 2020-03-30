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
using System.Collections.Generic;
using System.Windows.Forms;

namespace CardGame4
{
    public partial class Form1 : Form
    {
        private const int TWO = 2;
        private const int THREE = 3;
        private const int FOUR = 4;

        private Deck deck;
        private Random rand;
        public Form1()//constructor
        {
            InitializeComponent();
            rand = new Random();
            deck = new Deck(rand);
        }

        private void button1_Click(object sender, EventArgs e)//when deal a hand button is clicked
        {
            List<Card> hand = deck.DealAHand();
            pictureBox1.Image = hand[0].Image;
            pictureBox2.Image = hand[1].Image;
            pictureBox3.Image = hand[TWO].Image;
            pictureBox4.Image = hand[THREE].Image;
            pictureBox5.Image = hand[FOUR].Image;
            textBox1.Text = hand[0].ToString().ToLower();
            textBox2.Text = hand[1].ToString().ToLower();
            textBox3.Text = hand[TWO].ToString().ToLower();
            textBox4.Text = hand[THREE].ToString().ToLower();
            textBox5.Text = hand[FOUR].ToString().ToLower();
        }
    }
}
