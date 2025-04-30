using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // The Creature class is an abstract class that represents a creature in the game
    public abstract class Creature
    {
        // Properties for the Creature class
        private string name;
        private int health;

        // Constructor for the Creature class and initializes the name and health of the creature
        public Creature(string name, int health)
        {
            Name = name;
            Health = health;

        }

        // Method to set the name of the creature
        public string Name
        {
            get { return name; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("The name that has been entered is invaild.");
                    Console.WriteLine("Defaulting to Default");
                    name = "Default";
                }
                else
                {
                    name = value;
                }
            }
        }

        // Method to set the health of the creature
        public int Health
        {
            get { return health; }

            set
            {
                if (value < 1 || value > 100)
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
