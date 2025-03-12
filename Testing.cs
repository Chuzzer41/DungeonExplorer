using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public static class Testing
    {
        public static void PlayerTests()
        {
            // Test to initialization of Player
            var player = new Player("Hero", 50, new List<string> { "Small Health Potion", "Shield" });
            Debug.Assert(player.Name == "Hero", "Test Failed: Player's name should be 'Hero'");
            Debug.Assert(player.Health == 50, "Test Failed: Player's health should be 50");
            Debug.Assert(player.Inventory.Count == 2, "Test Failed: Player should have 2 items in inventory");

            // Test for invalid player name
            player.Name = "";
            Debug.Assert(player.Name == "DefaultPlayer", "Test Failed: Player's name should default to 'DefaultPlayer'");

            // Tests health setting
            player.Health = 101;
            Debug.Assert(player.Health == 0, "Test Failed: Player's health should be set to 0");

            // Tests inventory actions
            player.PickUpItem("Bandage");
            Debug.Assert(player.InventoryContents() == "Small Health Potion, Large Health Potion, Bandage", "Test Failed: Inventory content mismatch");
        }
    }
}
