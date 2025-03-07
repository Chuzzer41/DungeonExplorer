using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {


        private string name;
        private int health;
        private List<string> inventory;

        public Player(string name, int health, List<string> inventory)
        {
            name = Name;
            health = Health;
            inventory = Inventory;
        }
        public string Name 
        { 
            get {  return Name; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("The name that has been entered is invaild. Defaulting to DefaultPlayer");
                    Name = "DefaultPlayer";
                }
                else
                {
                    Name = value;
                }
            } 
        }


        public int Health
        {
            get { return Health; }

            set
            {
                if (value < 1)
                {
                    Health = 0;
                }
                else
                {
                    Health = value;
                }
            }
        }

        public List<string> Inventory
        {
            get { return Inventory; }

            set { Inventory = value; }
        }

        public void PickUpItem(string item)
        {

        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}