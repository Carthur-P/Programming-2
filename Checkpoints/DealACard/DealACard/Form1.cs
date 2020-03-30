/* Program name:          DealACard
 * Project file name:     DealACard
 * Author:                Carthur Pongpatimet
 * Date:                  31/07/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To generate a random card and display it on the form once the user click a button
 * 
 * Description:           Click the 'deal a card' button and a pictureBox will display a random image of
 *                        a card. The label will also show what the card's suit and rank is. 
 *                        
 * Known bugs:            None
 * Additional features:   None
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

namespace DealACard
{
    public partial class Form1 : Form
    {
        private Card picture;
        private Random rand;

        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            picture = new Card(pictureBox1,rand);          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picture.DealCard();
            label1.Text = picture.ChangeLabel();
        }
    }
}