using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory
    {
        private List<Item> items;
        public Inventory()
        {
            items = new List<Item>();
        }
        public void Add(Item item)
        {
            items.Add(item);
        }

        public void Remove(string ItemName)
        {
            var itemToRemove = items.FirstOrDefault(i => i.Name == ItemName);
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
            }
        }

        public bool Contains(string itemName)
        {
            return items.Any(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }

        public string ListContents()
        {
            if (items.Count == 0)
            {
                return "Nothing.";
            }
            return string.Join(", ", items.Select(i => i.Name));
        }
    }
}


