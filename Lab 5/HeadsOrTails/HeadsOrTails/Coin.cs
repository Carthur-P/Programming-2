using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsOrTails
{
    class Coin
    {
        private Random rand;

        private int result;
        private int headCount;
        private int tailCount;
        private string sideUp;

        private const int TOSS = 2;

        public Coin(Random rand)
        {
            tailCount = 0;
            headCount = 0;
            this.rand = rand;
        }//end of constructor


        public void Toss()
        {
            result = rand.Next(TOSS);

            switch(result)
            {
                case 0:
                    sideUp = "Heads";
                    headCount = headCount + 1;
                    break;

                case 1:
                    sideUp = "Tails";
                    tailCount = tailCount + 1;
                    break;

                default:
                    break;
            }//end of switch statement
        }//end of Throw method

        public string SideUp
        {
            get { return sideUp; }
        }

        public string HeadCount
        {
            get { return ("You have tossed " + headCount + " heads"); }
        }

        public string TailCount
        {
            get { return ("You have tossed " + tailCount + " tails"); }
        }

    }//end of class Coin

}
