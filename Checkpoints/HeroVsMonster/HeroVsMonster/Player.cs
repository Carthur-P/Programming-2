//This contains all the information and method that player in the game requires

using System;

namespace HeroVsMonster
{
    public class Player
    {
        protected int strength;
        protected int health;
        private string name;
        protected Random rand;

        public Player(int strength, int health, string name, Random rand)//constructor
        {
            this.strength = strength;
            this.health = health;
            this.name = name;
            this.rand = rand;
        }

        public int Attack()//attack by returning a number between 1 and the character's strenght
        {
            return rand.Next(1, strength);
        }

        public int Strength
        {
            get { return strength; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public string Name
        {
            get
            { return name; }
        }
    }
}
