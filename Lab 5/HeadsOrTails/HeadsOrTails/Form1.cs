/* Program name:          Heads or tails simulation
 * Project file name:     HeadsOrTails
 * Author:                Carthur Pongpatimet
 * Date:                  01/08/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To simulate a coin toss five times.
 * 
 * Description:           When the tossed five times button is clicked, the listbox should 
 *                        display the outcome of the five coin tosses.
 *                        When the show total results button is clicked, the total amount of times 
 *                        that the coin have landed heads and tails is showed.
 *                        When the exit button is clicked, the program will end.
 *                        
 * Known bugs:            None
 * 
 * Additional features:   A button which shows the total amount of times that the coin
 *                        have landed heads or tails.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeadsOrTails
{
    public partial class Form1 : Form
    {
        private Coin flipCoin;
        private Random rand;
        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            flipCoin = new Coin(rand);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 1; i <= 5; i++)
            {
                flipCoin.Toss();
                listBox1.Items.Add(flipCoin.SideUp);
            }//end of for loop
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(flipCoin.HeadCount);
            listBox1.Items.Add(flipCoin.TailCount);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
