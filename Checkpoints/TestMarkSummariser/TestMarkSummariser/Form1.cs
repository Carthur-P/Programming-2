/* Program name:          Test Mark Summariser
 * Project file name:     TestMarkSummariser
 * Author:                Carthur Pongpatimet
 * Date:                  05/09/17
 * Language:              C#
 * Platform:              Microsoft Visual Studio 2015
 * 
 * Purpose:               To create two listboxs filled with ten score test marks out of 100. The minimum, maximum and
 *                        average of these scores will be show.
 * 
 * Description:           One button will be use to generate 10 random test scores out of 100. These scores will be show 
 *                        listbox. Another button will be use to show the minimum, maximum and average of these scores in
 *                        textboxes.
 *                        
 * Known bugs:            None
 * 
 * Additional features:   None
 */

using System;
using System.Windows.Forms;

namespace TestMarkSummariser
{
    public partial class Form1 : Form
    {
        private const int SCORE = 10;

        private Data data1;
        private Data data2;
        private Summariser summariser;
        private Random rand;

        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            data1 = new Data(rand);
            data2 = new Data(rand);
            summariser = new Summariser();
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            ClearList();
            ClearData();
            CreateData();
            AddData();
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            textBox1.Text = summariser.FindMinimum(data1).ToString();
            textBox2.Text = summariser.FindMaximum(data1).ToString();
            textBox3.Text = summariser.Average(data1).ToString();

            textBox4.Text = summariser.FindMinimum(data2).ToString();
            textBox5.Text = summariser.FindMaximum(data2).ToString();
            textBox6.Text = summariser.Average(data2).ToString();
        }

        private void ClearList() //clearing all the items in the listbox
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void ClearData() //clearing the test scores stored in the list
        {
            data1.Score.Clear();
            data2.Score.Clear();
        }

        private void CreateData() //generating the test scores
        {
            data1.CreateScores();
            data2.CreateScores();
        }

        private void AddData() //adding the test scores into the listbox to display it
        {
            for (int i = 0; i < SCORE; i++)
            {
                listBox1.Items.Add(data1.Score[i]);
            }

            for (int i = 0; i < SCORE; i++)
            {
                listBox2.Items.Add(data2.Score[i]);
            }
        }
    }
}
