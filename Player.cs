using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
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

        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
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