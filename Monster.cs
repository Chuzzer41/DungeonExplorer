using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster : Creature
    {
        public string Type { get; set; }
        public int Health { get; set; }

        public Monster(string name, int health, string type)
            : base(name, health)
        {
            Type = type;
            Health = health;
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks!");
        }
        public virtual void Attack(Player player)
        {
            // Default attack method for the monster

            Console.WriteLine($"{Name} attacks {player.Name}!");
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


        public virtual int GetDamage()
        {
            Random random = new Random();
            return random.Next(1, 10); // Random default damage between 1 and 10
        }
    }


    public class SmallMonster : Monster
    {
        public SmallMonster(string name, int health)
            : base(name, health, "SmallMonster")
        {
        }
        public override int GetDamage()
        {
            Random random = new Random();
            return random.Next(1, 5);
        }

        public override void Attack(Player player)
        {
            // SmallMonster specific attack logic
            Random random = new Random();

            bool ContactHit = new Random().Next(0, 100) < 30;
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
        public RegularMonster(string name, int health)
            : base(name, health, "RegularMonster")
        {
        }
        public override int GetDamage()
        {
            Random random = new Random();
            return random.Next(5, 15); 
        }

        public override void Attack(Player player)
        {
            // RegularMonster specific attack logic
            Random random = new Random();
            bool ContactHit = new Random().Next(0, 100) < 50;
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
        public LargeMonster(string name, int health)
            : base(name, health, "LargeMonster")
        {
        }
        public override int GetDamage()
        {
            Random random = new Random();
            return random.Next(15, 30);
        }

        public override void Attack(Player player)
        {
            // LargeMonster specific attack logic
            Random random = new Random();
            bool ContactHit = new Random().Next(0, 100) < 70;
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