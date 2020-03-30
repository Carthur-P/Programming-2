using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsOrTails
{
    public class Coin
    {
        private const int TOSS = 2;

        private Random rand;
        private int result;
        private int headCount;
        private int tailCount;
        private string sideUp;

        public Coin(Random rand)
        {
            tailCount = 0;
            headCount = 0;
            this.rand = rand;
        }

        public void Toss()
        {
            result = rand.Next(TOSS);
            //generating a number between 0 an 1 to be use as heads or tails

            switch(result)
            {
                case 0:
                    sideUp = "Heads";
                    //this will assign the head side of the coin to the number 0
                    headCount = headCount + 1;
                    //adding the count of how many times heads have come up by one
                    break;

                case 1:
                    sideUp = "Tails";
                    //this will assign the tail side of the coin to the number 1
                    tailCount = tailCount + 1;
                    //adding the count of how many times tails have come up by one
                    break;

                default:
                    break;
            }
            //this switch statement determines the outcome of the toss, 0 is heads and 1 is tails
        }

        public string SideUp
        {
            get { return sideUp; }
        }
        //returning the value in the feild 'sideUp'

        public int HeadCount
        {
            get { return (headCount); }
        }
        //returning the value in the field 'headCount'

        public int TailCount
        {
            get { return (tailCount); }
        }
        //returning the value in the field 'tailCount'
    }
}
