using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // The Item class is an abstract class that represents an item in the game
    public abstract class Item : IUsable, ICollectible
    {
        // Properties for the Item class
        public string Name { get; set; }
        public Item(string name)
        {
            Name = name;
        }
        public abstract void Use(Player player);

        // Method to pick up the item and add it to the player's inventory
        public void PickUp(Player player)
        {
            player.Inventory.Add(this);
            Console.WriteLine($"{Name} has been added to your inventory.");
        }
    }


    // The SmallHealthPotion class is a subclass of Item that represents a small health potion
    public class SmallHealthPotion : Item
    {
        // Healing value for the small health potion
        private int HealingValue = 10;
        public SmallHealthPotion () : base("Small Health Potion")
        {
        }
        // Method that overrides the base class method for using the item
        public override void Use(Player player)
        {
            // Checks if the player's health is less than or equal to 90 to allow healing
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

    // The LargeHealthPotion class is a subclass of Item that represents a large health potion
    public class LargeHealthPotion : Item
    {
        // Healing value for the large health potion
        private int HealingValue = 20;
        public LargeHealthPotion() : base("Large Health Potion")
        {
        }
        // Method that overrides the base class method for using the item
        public override void Use(Player player)
        {
            // Checks if the player's health is less than or equal to 80 to allow healing
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

    // The Bandage class is a subclass of Item that represents a bandage
    public class Bandage : Item
    {
        private int HealingValue = 5;
        public Bandage() : base("Bandage")
        {
        }
        // Method that overrides the base class method for using the item
        public override void Use(Player player)
        {
            // Checks if the player's health is less than or equal to 95 to allow healing
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

    // The Weapon class is a subclass of Item that represents a weapon in the game
    public class Weapon : Item
    {
        // Properties for the Weapon class
        public int DamageValue { get; set; }
        public int HitChance { get; set; }
        // Constructor for the Weapon class and initializes the name, damage value, and hit chance of the weapon
        public Weapon(string name, int damageValue, int hitChance) : base(name)
        {
            DamageValue = damageValue;
            HitChance = hitChance;
        }
        // Method that overrides the base class method for using the item
        public override void Use(Player player)
        {
            Console.WriteLine($"{player.Name} has equipped the {Name}.");
        }
    }

    // The Sword class is a subclass of Weapon that represents a sword
    public class Sword : Weapon
    {
        // Constructor for the Sword class and initializes the name, damage value, and hit chance of the sword
        public Sword() : base("Sword", 15, 80)
        {
        }
    }

    // The Bow class is a subclass of Weapon that represents a bow
    public class Bow : Weapon
    {
        // Constructor for the Bow class and initializes the name, damage value, and hit chance of the bow
        public Bow() : base("Bow", 10, 95)
        {
        }
    }

    // The Axe class is a subclass of Weapon that represents an axe
    public class Axe : Weapon
    {
        // Constructor for the Axe class and initializes the name, damage value, and hit chance of the axe
        public Axe() : base("Axe", 20, 75)
        {
        }
    }
}
