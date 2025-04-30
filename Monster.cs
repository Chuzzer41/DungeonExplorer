using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// The Monster class is an abstract class that represents a monster in the game
    public class Monster : Creature, IDamageable
    {
        public string Type { get; set; }
        public int Health { get; set; }

        // Constructor for the Monster class and initializes the name, health, and type of the monster
        public Monster(string name, int health, string type)
            : base(name, health)
        {
            Type = type;
            Health = health;
        }

        //Method that overrides the base class method for the attack
        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks!");
        }

        // Method to attack the player
        public virtual void Attack(Player player)
        {
            // Monster specific attack logic
            Console.WriteLine($"{Name} attacks {player.Name}!");
            // Sets a random chance to hit the player
            bool ContactHit = new Random().Next(0, 100) < 20;
            if (ContactHit)
            {
                Console.WriteLine("You hit the monster");
                player.Health -= 20; 
            }
            else
            {
                Console.WriteLine("You missed the monster");
            }
        }

        // Method to take damage from the player
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has been defeated!");
            }
            else
            {
                Console.WriteLine($"{Name} has {Health} health remaining.");
            }
        }

        // Method to get the damage value for the monster
        public virtual int GetDamage()
        {
            Random random = new Random();
            return random.Next(1, 10); // Random default damage between 1 and 10
        }
    }


    // Derived classes for different types of monsters
    public class SmallMonster : Monster
    {
        // Constructor for the SmallMonster class and initializes the name and health of the small monster
        public SmallMonster(string name, int health)
            : base(name, health, "SmallMonster")
        {
        }
        // Method to override the base class method for the getDamge with a different damage value
        public override int GetDamage()
        {
            Random random = new Random();
            return random.Next(1, 5);
        }
         
        // Method to override the base class method for the attack with a different chance to hit
        public override void Attack(Player player)
        {
            // SmallMonster specific attack logic
            Random random = new Random();

            // Sets a random chance to hit the player
            bool ContactHit = new Random().Next(0, 100) < 70;
            if (ContactHit)
            {
                int damage = GetDamage();
                Console.WriteLine("The monster hit you");
                player.Health -= damage; // Example damage value for small monster
            }
            else
            {
                Console.WriteLine("The monster tried to atatck you but missed");
            }
        }
    }

    public class RegularMonster : Monster
    {
        // Constructor for the RegularMonster class and initializes the name and health of the regular monster
        public RegularMonster(string name, int health)
            : base(name, health, "RegularMonster")
        {
        }
        // Method to override the base class method for the getDamge with a different damage value
        public override int GetDamage()
        {
            Random random = new Random();
            return random.Next(5, 15); 
        }

        // Method to override the base class method for the attack with a different chance to hit
        public override void Attack(Player player)
        {
            // RegularMonster specific attack logic
            Random random = new Random();
            // Sets a random chance to hit the player
            bool ContactHit = new Random().Next(0, 100) < 90;
            if (ContactHit)
            {
                int damage = GetDamage();
                Console.WriteLine("The monster hit you");
                player.Health -= damage; // Example damage value for regular monster
            }
            else
            {
                Console.WriteLine("The monster tried to atatck you but missed");
            }
        }
    }

    public class LargeMonster : Monster
    {
        // Constructor for the LargeMonster class and initializes the name and health of the large monster
        public LargeMonster(string name, int health)
            : base(name, health, "LargeMonster")
        {
        }
        // Method to override the base class method for the getDamge with a different damage value
        public override int GetDamage()
        {
            Random random = new Random();
            return random.Next(15, 20);
        }

        // Method to override the base class method for the attack with a different chance to hit
        public override void Attack(Player player)
        {
            // LargeMonster specific attack logic
            Random random = new Random();
            // Sets a random chance to hit the player
            bool ContactHit = new Random().Next(0, 100) < 80;
            if (ContactHit)
            {
                int damage = GetDamage();
                Console.WriteLine("The monster hit you");
                player.Health -= damage; // Example damage value for large monster
            }
            else
            {
                Console.WriteLine("The monster tried to atatck you but missed");
            }
        }
    }
}