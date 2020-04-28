using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Form1 : Form
    {
        private Random rand;
        private Deck deck;
        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            deck = new Deck(rand);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Card card = deck.DealACard();
            pictureBox1.Image = card.Image;
            textBox1.Text = card.ToString().ToLower();
        }

    }
}
