//This class will generate a set of test scores and store it in a list

using System;
using System.Collections.Generic;

namespace TestMarkSummariser
{
    public class Data
    {
        private const int TESTNUM = 10;
        private const int MAXSCORE = 100;

        private Random rand;
        private List<int> score;

        public Data(Random rand)
        {
            score = new List<int>();
            this.rand = rand;    
        }

        public void CreateScores() //generate 10 random test scores out of 100
        {
            for (int i = 0; i < TESTNUM; i++)
            {
                score.Add(rand.Next(MAXSCORE));
            }
        }

        public List<int> Score
        {
            get
            {
                return score;
            }
        }
    }
}
