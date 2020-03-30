//This class will find the minimum, maximum and average of the scores generated in the data class

using System.Linq;

namespace TestMarkSummariser
{
    public class Summariser
    {
        public Summariser()
        {

        }

        public int FindMinimum(Data data) //find mimimum of test scores
        {
            int minimum;
            minimum = data.Score[0];

            foreach (int score in data.Score)
            {
                if (score < minimum)
                {
                    minimum = score;
                }
            }
            return minimum;
        }

        public int FindMaximum(Data data) //find maximum of test scores
        {
            int maximum;
            maximum = data.Score[0];

            foreach (int score in data.Score)
            {
                if (score > maximum)
                {
                    maximum = score;
                }
            }
            return maximum;
        }

        public double Average(Data data) //find average of test scores
        {
            double average;
            average = data.Score.Sum() / (double)data.Score.Count();
            return average;
        }
    }
}
