using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Creature, IDamageable
    {
        // Properties for the Player class
        public Inventory Inventory { get; set; }
        public Weapon equippedWeapon { get; set; }

        // Constructor for the Player class and initializes the name, health, and inventory of the player
        public Player(string Name, int Health)
            : base(Name, Health)
        {
            // Initializes the player's name and health
            Inventory = new Inventory();
            equippedWeapon = null;
        }

        // Method to attack a monster changing depending on the players weapon or lack of one
        public void Attack(Monster monster)
        {
            Console.WriteLine("");
            // Checks if the player has a weapon equipped
            if (equippedWeapon != null)
            {
                // If the player has a weapon, it checks if the attack hits based on the weapon's hit chance
                bool ContactHit = new Random().Next(0, 100) < equippedWeapon.HitChance;
                if (ContactHit)
                {
                    // If the attack hits, it reduces the monster's health by the weapon's damage value
                    Console.WriteLine($"You hit the {monster.Name} with your {equippedWeapon.Name}!");
                    monster.Health -= equippedWeapon.DamageValue;
                }
                else
                {
                    // If the attack misses, it displays a message indicating the miss
                    Console.WriteLine($"You missed the {monster.Name} with your {equippedWeapon.Name}.");
                }
            }
            else
            {
                // If the player does not have a weapon equipped, it uses a default fist attack
                // Sets a random chance to hit the monster for tne fist attack
                bool ContactHit = new Random().Next(0, 100) < 80; 
                if (ContactHit)
                {
                    // If the attack hits, it reduces the monster's health by a default fist damage value
                    int FistDamage = 5;
                    Console.WriteLine($"You hit the {monster.Name}!");
                    monster.Health -= FistDamage; // Default damage value
                }
                else
                {
                    // If the attack misses, it displays a message indicating the miss
                    Console.WriteLine($"You missed the {monster.Name}.");
                }
            }

        }

        // Method for the player to take damage
        public void TakeDamage(int damage)
        {
            // Reduces the player's health by the damage value
            Health -= damage;
            if (Health <= 0)
            {
                // If the player's health drops to 0 or below, it displays a message indicating defeat
                Console.WriteLine($"{Name} has been defeated!");
            }
            else
            {
                // If the player is still alive, it displays the remaining health
                Console.WriteLine($"{Name} took {damage} damage and has {Health} health left.");
            }
        }

        // Override the Attack method from the Creature class and display a message indicating the player is attacking
        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks!");
        }
    }
}