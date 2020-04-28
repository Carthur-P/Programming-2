using System;
using System.Windows.Forms;

namespace InheritanceExample5
{
    public partial class Form1 : Form
    {
        private Bird tweety;
        private Vertebrate barney;

        public Form1()
        {
            InitializeComponent();
            tweety = new Bird(2, 7.5);
            barney = new Vertebrate(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I have just create a bird called Tweety.\nTweety has " 
                + tweety.Legs + " legs and a wingspan of " + tweety.WingSpan + " cm");

            MessageBox.Show("Tweety ate " + tweety.Eat("seeds", 8));

            MessageBox.Show("I have just create a vertibrate called Barney.\nBarney has "
               + barney.Legs + " legs");

            MessageBox.Show("Barney ate " + barney.Eat("bannana", 5));
        }
    }
}
