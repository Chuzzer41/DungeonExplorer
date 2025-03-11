using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        private string name;
        private int health;
        private List<string> inventory;

        // Constructor for the Player class and initializes the name, health, and inventory of the player
        public Player(string Name, int Health, List<string> Inventory)
        {
            name = Name;
            health = Health;
            inventory = Inventory;
        }

        // Getters and Setters for the name, health, and inventory of the player
        public string Name 
        { 
            get {  return name; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // If the name is null or empty, set the name to "DefaultPlayer"
                    Console.WriteLine("The name that has been entered is invaild. Defaulting to DefaultPlayer");
                    name = "DefaultPlayer";
                }
                else
                {
                    name = value;
                }
            } 
        }

        // If the health is less than 1 or greater than or equal to 100, set the health to 0 else set the health to the value
        public int Health
        {
            get { return health; }

            set
            {
                if (value < 1 && value >= 100)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        // Gets the inventory of the player
        public List<string> Inventory
        {
            get { return inventory; }

            set { inventory = value; }
        }

        // Method to pick up an item and add it to the inventory
        public void PickUpItem(string item)
        {
            Inventory.Add(item);
        }

        // Method displays the contents of the inventory but if the inventory is empty, it will return "Nothing."
        public string InventoryContents()
        {
            if (inventory.Count == 0)
            {
                return "Nothing.";
            }
            return string.Join(", ", inventory);
        }
    }
}