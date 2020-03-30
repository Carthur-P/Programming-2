//This class is the game engine and it controls the gameplay of the game and all the game's functions

using System;
using System.Windows.Forms;

namespace HeroVsMonster
{
    public class Controller
    {
        private const int TEN = 10;
        private const int FIVE = 5;
        private const int FIFTY = 50;
        private const int ATTACKSUCCESS = 5;

        private Random rand;
        private Player player;
        private Hero hero;
        private bool heroTurn;
        private bool gameRun;
        Label heroStat;
        Label monsterStat;
        Label heroAction;
        Label monsterAction;
        Label heroRecover;
        Label gameStatus;

        public Controller(Random rand, Label heroStat, Label monsterStat, Label heroAction, 
            Label monsterAction, Label heroRecover, Label gameStatus)//constructor
        {
            this.rand = rand;
            this.heroStat = heroStat;
            this.monsterStat = monsterStat;
            this.heroAction = heroAction;
            this.monsterAction = monsterAction;
            this.heroRecover = heroRecover;
            this.gameStatus = gameStatus;
            heroTurn = true;
        }

        public void GameRun()//running the game, this is what happens everytime the timer ticks
        {
            heroAction.Text = " ";
            monsterAction.Text = " ";
            heroRecover.Text = " ";

            if (heroTurn == true)
            {
                heroAction.Text = HeroAttack();
                heroRecover.Text = hero.Recover();
                heroTurn = false;
            }

            else if (heroTurn == false)
            {
                monsterAction.Text = MonsterAttack();
                heroTurn = true;
            }

            heroStat.Text = "Strength: " + hero.Strength + "\n" + "Health: " + hero.Health;
            monsterStat.Text = "Strength: " + player.Strength + "\n" + "Health: " + player.Health;
        }

        public void NewGame()//setting up for a new game
        {
            player = new Player((TEN + rand.Next(FIFTY)), rand.Next(FIVE, FIFTY), "Monster", rand);
            hero = new Hero(TEN, TEN, "Hero", rand);
            heroStat.Text = "Strength: " + hero.Health + "\n" + "Health: " + hero.Health;
            monsterStat.Text = "Strength: " + player.Strength + "\n" + "Health: " + player.Health;
            heroAction.Text = " ";
            monsterAction.Text = " ";
            heroRecover.Text = " ";
            gameStatus.Text = " ";
            gameRun = true;
        }

        public bool EndGame()//checking if the game should end 
        {
            if (hero.Health <= 0)
            {
                gameStatus.Text = "Monster wins!";
                gameRun = false;
            }

            if (player.Health <= 0)
            {
                gameStatus.Text = "Hero wins!";
                gameRun = false;
            }

            return gameRun;
        }

        private string HeroAttack()//getting the hero to attack
        {
            string message = " ";
            int attack = hero.Attack();

            if (attack >= ATTACKSUCCESS)//attack is successful
            {
                player.Health = player.Health - 1;
                message = hero.Name + " attack succesful";
            }

            else if (attack < ATTACKSUCCESS)//attack is not successful
            {
                message = hero.Name + " attack was blocked";
            }

            return message;
        }

        private string MonsterAttack()//getting the monster to attack
        {
            string message = " ";
            int attack = player.Attack();

            if (attack >= ATTACKSUCCESS)//attack is not successful
            {
                hero.Health = hero.Health - 1;
                message = player.Name + " attack succesful";
            }

            else if (attack < ATTACKSUCCESS)//attack is not successful
            {
                message = player.Name + " attack was blocked";
            }

            return message;
        }
    }
}
