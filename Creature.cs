using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        private string name;
        private int health;

        public Creature(string name, int health)
        {
            Name = name;
            Health = health;

        }

        public string Name
        {
            get { return name; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("The name that has been entered is invaild.");
                    Console.WriteLine("Defaulting to DefaultCreature");
                    name = "DefaultCreature";
                }
                else
                {
                    name = value;
                }
            }
        }

        public int Health
        {
            get { return health; }

            set
            {
                if (value < 1 || value >= 100)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public abstract void Attack();
    }
}
