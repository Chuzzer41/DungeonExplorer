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
            Console.WriteLine("Testing Player class");

            Player player = new Player("TestPlayer", 100);
            Debug.Assert(player.Name == "TestPlayer", "Test Failed: Player's name should be 'TestPlayer'");
            Debug.Assert(player.Health == 100, "Test Failed: Player's health should be 100");
            Debug.Assert(player.Inventory != null, "Test Failed: Player's inventory should not be null");
            Weapon sword = new Weapon("Sword", 10, 80);
            sword.PickUp(player);
            Debug.Assert(player.equippedWeapon == null, "Test Failed: Player's equipped weapon should be null");

            Console.WriteLine("No issues");
        }

        public static void InventoryTests()
        {
            Console.WriteLine("Testing Inventory class");

            Player player = new Player("TestPlayer", 100);

            SmallHealthPotion smallPotion = new SmallHealthPotion();
            smallPotion.PickUp(player);
            Debug.Assert(player.Inventory.Items.Count == 1, "Test Failed: Inventory should contain 1 item after picking up a potion");
            Debug.Assert(player.Inventory.Contains("Small Health Potion"), "Test Failed: Inventory should contain 'Small Health Potion'");
            Debug.Assert(player.Inventory.ListContents() == "Small Health Potion", "Test Failed: Inventory contents should be 'Small Health Potion'");
            player.Inventory.Remove("Small Health Potion");
            Debug.Assert(player.Inventory.Items.Count == 0, "Test Failed: Inventory should be empty after removing the potion");
            Debug.Assert(!player.Inventory.Contains("Small Health Potion"), "Test Failed: Inventory should not contain 'Small Health Potion' after removal");
            Debug.Assert(player.Inventory.ListContents() == "Nothing.", "Test Failed: Inventory should be empty");

            LargeHealthPotion largePotion = new LargeHealthPotion();
            largePotion.PickUp(player);
            player.Health = 50;
            largePotion.Use(player);
            Debug.Assert(player.Health == 70, "Test Failed: Player's health should be 70 after using a Large Health Potion");

            Bandage bandage = new Bandage();
            bandage.PickUp(player);
            player.Health = 50;
            bandage.Use(player);
            Debug.Assert(player.Health == 55, "Test Failed: Player's health should be 70 after using a Bandage");

            player.Health = 97;
            bandage.Use(player);
            Debug.Assert(player.Health == 97, "Test Failed: Player's health should be the same");

            Console.WriteLine("No issues");
        }


        public static void RoomTests()
        {
            Console.WriteLine("Testing Room class");

            Player player = new Player("TestPlayer", 100);
            Monster monster = new Monster("TestMonster", 50, "TestType");
            Room room = new Room(monster);
            int roomNumber = 1;
            Debug.Assert(player.Health == 100, "Test Failed: Player's health should be 100 after entering the room");
            room.GetRoomDescription(player, ref roomNumber);
            Debug.Assert(monster != null, "Test Failed: Monster should not be null");

            Room room1 = Room.RandomRoom();
            Debug.Assert(room1 != null, "Test Failed: Random room should not be null");

            Room room2 = new Room(null);
            room2.GetRoomDescription(player, ref roomNumber);


            Player player1 = new Player("TestPlayer", 100);
            Weapon sword = new Weapon("Sword", 10, 80);
            player1.equippedWeapon = sword;
            Monster monster1 = new Monster("TestMonster", 50, "TestType");
            Room room3 = new Room(monster1);

            Console.WriteLine("No issues");
        }
    }
}
