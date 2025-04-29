using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Item
    {
        public string Name { get; set; }
        public Item(string name)
        {
            Name = name;
        }
        public abstract void Use(Player player);
    }
    
    public class SmallHealthPotion : Item
    {
        private int HealingValue = 10;
        public SmallHealthPotion () : base("Small Health Potion")
        {
        }
        public override void Use(Player player)
        {
            if (player.Health <= 90)
            {
                player.Health += HealingValue;
                Console.WriteLine("You have used a Small Health Potion.");
                Console.WriteLine("Your health is now " + player.Health);
            }
            else
            {
                Console.WriteLine("Your health is too high.");
            }
        }
    }


    public class LargeHealthPotion : Item
    {
        private int HealingValue = 20;
        public LargeHealthPotion() : base("Large Health Potion")
        {
        }
        public override void Use(Player player)
        {
            if (player.Health <= 80)
            {
                player.Health += HealingValue;
                Console.WriteLine("You have used a Large Health Potion.");
                Console.WriteLine("Your health is now " + player.Health);
            }
            else
            {
                Console.WriteLine("Your health is too high.");
            }
        }
    }

    public class Bandage : Item
    {
        private int HealingValue = 5;
        public Bandage() : base("Health Potion")
        {
        }
        public override void Use(Player player)
        {
            if (player.Health <= 95)
            {
                player.Health += HealingValue;
                Console.WriteLine("You have used a bandgae.");
                Console.WriteLine("Your health is now " + player.Health);
            }
            else
            {
                Console.WriteLine("Your health is too high.");
            }
        }
    }


    public class Weapon : Item
    {
        public int DamageValue { get; set; }
        public int HitChance { get; set; }
        public Weapon(string name, int damageValue, int hitChance) : base(name)
        {
            DamageValue = damageValue;
            HitChance = hitChance;
        }
        public override void Use(Player player)
        {
            Console.WriteLine($"{player.Name} has equipped the {Name}.");
        }
    }

    public class Sword : Weapon
    {
        public Sword() : base("Sword", 15, 70)
        {
        }
    }

    public class Bow : Weapon
    {
        public Bow() : base("Bow", 10, 90)
        {
        }
    }

    public class Axe : Weapon
    {
        public Axe() : base("Axe", 20, 40)
        {
        }
    }
}
