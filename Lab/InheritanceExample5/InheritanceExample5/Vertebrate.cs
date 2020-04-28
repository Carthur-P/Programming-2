namespace InheritanceExample5
{
    public class Vertebrate
    {
        protected int legs;//when using inheritance, if you want your child class to be able to access this field, use protected

        public Vertebrate(int legs)
        {
            this.legs = legs;
        }

        public string Eat(string food, int quantity)
        {
            return (quantity.ToString() + " " + food);
        }

        public int Legs
        {
            get
            {
                return legs;
            }
        }
    }
}
