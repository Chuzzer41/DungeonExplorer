using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // The Inventory class represents the player's inventory
    public class Inventory
    {
        private List<Item> items;
        // Constructor for the Inventory class and initializes the items list
        public Inventory()
        {
            items = new List<Item>();
        }
        // Method to add an item to the inventory
        public void Add(Item item)
        {
            items.Add(item);
        }

        // Method to remove an item from the inventory by name
        public void Remove(string ItemName)
        {
            var itemToRemove = items.FirstOrDefault(i => i.Name == ItemName);
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
            }
        }
        // Method to check if the inventory contains an item by name
        public bool Contains(string itemName)
        {
            return items.Any(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }
        // Method to list the contents of the inventory
        public string ListContents()
        {
            if (items.Count == 0)
            {
                return "Nothing.";
            }
            return string.Join(", ", items.Select(i => i.Name));
        }
        // Provides a read only view of the inventory items
        public IReadOnlyList<Item> Items
        {
            get { return items.AsReadOnly(); }
        }
    }
}


