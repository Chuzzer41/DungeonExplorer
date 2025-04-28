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

        public Monster(string name, int health, string type)
            : base(name, health)
        {
            Type = type;
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks!");
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
            return random.Next(1, 10); // Random damage between 1 and 5 for Goblin
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
            return random.Next(10, 20); // Random damage between 3 and 8 for Orc
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
            return random.Next(20, 30); // Random damage between 5 and 15 for Troll
        }
    }
}
