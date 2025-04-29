using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Creature
    {

        public Inventory Inventory { get; set; }
        public Weapon equippedWeapon { get; set; }

        // Constructor for the Player class and initializes the name, health, and inventory of the player
        public Player(string Name, int Health)
            : base(Name, Health)
        {
            Inventory = new Inventory();
            equippedWeapon = null;
        }

        
        public void Attack(Monster monster)
        {
            if (equippedWeapon != null)
            {
                bool ContactHit = new Random().Next(0, 100) < equippedWeapon.HitChance;
                if (ContactHit)
                {
                    Console.WriteLine($"You hit the {monster.Name} with your {equippedWeapon.Name}!");
                    monster.Health -= equippedWeapon.DamageValue;
                }
                else
                {
                    Console.WriteLine($"You missed the {monster.Name} with your {equippedWeapon.Name}.");
                }
            }
            else
            {
                bool ContactHit = new Random().Next(0, 100) < 50; // Default hit chance
                if (ContactHit)
                {
                    int FistDamage = 5;
                    Console.WriteLine($"You hit the {monster.Name}!");
                    monster.Health -= FistDamage; // Default damage value
                }
                else
                {
                    Console.WriteLine($"You missed the {monster.Name}.");
                }
            }

        }


        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks!");
        }
    }
}