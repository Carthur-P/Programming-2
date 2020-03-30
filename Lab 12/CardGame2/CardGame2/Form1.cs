using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame2
{
    public partial class Form1 : Form
    {
        private const int TWO = 2;
        private const int THREE = 3;
        private const int FOUR = 4;

        private Hand hand;
        private Random rand;
        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            hand = new Hand(rand); 
        }

        private void button1_Click(object sender, EventArgs e)
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
            hand.FiveCards.Clear();
        }
    }
}
