using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {


        private string name;
        private int health;
        private List<string> inventory;

        public Player(string Name, int Health, List<string> Inventory)
        {
            name = Name;
            health = Health;
            inventory = Inventory;
        }
        public string Name 
        { 
            get {  return name; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("The name that has been entered is invaild. Defaulting to DefaultPlayer");
                    name = "DefaultPlayer";
                }
                else
                {
                    name = value;
                }
            } 
        }


        public int Health
        {
            get { return health; }

            set
            {
                if (value < 1)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public List<string> Inventory
        {
            get { return inventory; }

            set { inventory = value; }
        }

        public void PickUpItem(string item)
        {
            Inventory.Add(item);
        }
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