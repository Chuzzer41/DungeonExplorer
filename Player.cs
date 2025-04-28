using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Creature
    {

        private List<string> inventory;

        // Constructor for the Player class and initializes the name, health, and inventory of the player
        public Player(string Name, int Health, List<string> Inventory)
            : base(Name, Health)
        {
            this.inventory = Inventory;
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

        public override void Attack()
        {
            throw new NotImplementedException();
        }
    }
}