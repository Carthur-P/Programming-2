namespace InheritanceExample5
{
    public class Bird : Vertebrate
    {
        private double wingSpan;

        public Bird(int legs, double wingSpan)
            : base(legs) //this will go to the inheritance class and populate the legs field
        {
            this.wingSpan = wingSpan;
            this.legs = legs;
        }

        public string Fly()
        {
            return ("I can fly");
        }

        public double WingSpan
        {
            get
            {
                return wingSpan;
            }
        }
    }
}
