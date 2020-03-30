//does everything that the player class does but hero class can also recover

using System;

namespace HeroVsMonster
{
    public class Hero : Player
    {
        private const int CHANCE = 10;
        private const int CRITERIA = 8;
        private const int HEALTHGAIN = 2;

        public Hero(int strength, int health, string name, Random rand)
            : base (strength, health, name, rand) //constructor
        {
             
        }

        public string Recover()//checking if the hero should recover
        {
            int chance = rand.Next(CHANCE);
            string messgae = " ";

            if (chance >= CRITERIA)
            {
                health = health + HEALTHGAIN;
                messgae = "Hero have recovered 2 health";
            }

            return messgae;
        }
    }
}
