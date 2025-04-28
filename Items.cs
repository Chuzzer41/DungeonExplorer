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
        public int HealingValue { get; set; }
        public Item(string name, int healingValue)
        {
            Name = name;
            HealingValue = healingValue;
        }
        public abstract void Use(Player player);
    }
    
    public class SmallHealthPotion : Item
    {
      public SmallHealthPotion () : base("Small Health Potion", 10)
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

    public class RegularHealthPotion : Item
    {
        public RegularHealthPotion() : base("Regular Health Potion", 20)
        {
        }
        public override void Use(Player player)
        {
            if (player.Health <= 80)
            {
                player.Health += HealingValue;
                Console.WriteLine("You have used a Regular Health Potion.");
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
        public LargeHealthPotion() : base("Large Health Potion", 30)
        {
        }
        public override void Use(Player player)
        {
            if (player.Health <= 70)
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
        public Bandage() : base("Health Potion", 5)
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
}