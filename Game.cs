using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        private Player Player;
        private int RoomNumber;
        private int TotalRoomNumber;

        public const string SmallHealthPotion = "Small Health Potion";
        public const string LargeHealthPotion = "Large Health Potion";
        public const string Bandage = "Bandage";
        public Game()
        {
            Player = new Player("", 100, new List<string>());
            currentRoom = Room.RandomRoom();
            RoomNumber = 0;
            TotalRoomNumber = 5;
        }

        public void PlayersDecision()
        {
            Console.WriteLine();
            Console.WriteLine("Which direction would you like to go: forward, left, right?");

            string input = Console.ReadLine().ToLower().Trim();

            Room nextRoom;
            switch (input)
            {
                case "forward":
                    nextRoom = Room.RandomRoom();
                    nextRoom.GetRoomDescription(Player, ref RoomNumber);
                    ItemProbability();
                    break;

                case "left":
                    nextRoom = Room.RandomRoom();
                    nextRoom.GetRoomDescription(Player, ref RoomNumber);
                    ItemProbability();
                    break;

                case "right":
                    nextRoom = Room.RandomRoom();
                    nextRoom.GetRoomDescription(Player, ref RoomNumber);
                    ItemProbability();
                    break;

                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
           
        }

        public void ItemProbability()
        {
            Random rnd = new Random();
            int random = rnd.Next(0, 5);
            switch (random)
            {
                case 0:
                    Player.Inventory.Add(SmallHealthPotion);
                    Console.WriteLine("You have found a small health potion.");
                    break;
                case 1:
                    Player.Inventory.Add(LargeHealthPotion);
                    Console.WriteLine("You have found a large health potion.");
                    break;
                case 2:
                    Player.Inventory.Add(Bandage);
                    Console.WriteLine("You have found a bandage.");
                    break;
                case 3:
                case 4:
                    break;
            }
        }

        public void ItemUse()
        {
            Console.WriteLine("Which item would you like to use: bandage, small or large health potion (b, s, l)");
            string item = Console.ReadLine().ToLower().Trim();
            switch (item)
            {
                case "s":
                    if (Player.Inventory.Contains(SmallHealthPotion))
                    {
                        if (Player.Health > 90)
                        {
                            Player.Health += 10;
                            Player.Inventory.Remove(SmallHealthPotion);
                            Console.WriteLine("You have used a small health potion.");
                            Console.WriteLine("Your health is now " + Player.Health);
                        }
                        else
                        {
                            Console.WriteLine("Your health is too high.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You do not have a small health potion.");
                    }
                    break;
                case "l":
                    if (Player.Inventory.Contains(LargeHealthPotion))
                    {
                        if (Player.Health > 20)
                        {
                            Player.Health += 20;
                            Player.Inventory.Remove(LargeHealthPotion);
                            Console.WriteLine("You have used a large health potion.");
                            Console.WriteLine("Your health is now " + Player.Health);

                        }
                        else
                        {
                            Console.WriteLine("Your health is too high.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You do not have a large health potion.");
                    }
                    break;
                case "b":
                    if (Player.Inventory.Contains(Bandage))
                    {
                        if (Player.Health > 95)
                        {
                            Player.Health += 5;
                            Player.Inventory.Remove(Bandage);
                            Console.WriteLine("You have used a bandage.");
                            Console.WriteLine("Your health is now " + Player.Health);

                        }
                        else
                        {
                            Console.WriteLine("Your health is too high.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You do not have a bandage.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input. Press any button to continue.");
                    Console.ReadKey();
                    break;
            }
        }

        public void PlayersHealth()
        {
            Console.WriteLine("Would you like to see your health? yes or no");
            string input = Console.ReadLine().ToLower().Trim();
            switch(input)
            {
                case "yes":
                    Console.WriteLine("Your health is " + Player.Health);
                    break;
                case "no":
                    break;
                default:
                    Console.WriteLine("Invalid input. Press any button to continue.");
                    Console.ReadKey();
                    break;
            }
        }

        public void PlayersInventory()
        {
            Console.WriteLine("Would you like to see your inventory? yes or no");
            string input = Console.ReadLine().ToLower().Trim();
            switch (input)
            {
                case "yes":
                    Console.WriteLine("Your inventory contains: ");
                    Console.WriteLine(Player.InventoryContents());
                    break;
                case "no":
                    break;
                default:
                    Console.WriteLine("Invalid input. Press any button to continue.");
                    Console.ReadKey();
                    break;
            }
        }

        public void DecisionToUseItem()
        {
            Console.WriteLine("Would you like to use an item? yes or no");
            string input = Console.ReadLine().ToLower().Trim();
            switch (input)
            {
                case "yes":
                    ItemUse();
                    break;
                case "no":
                    break;
                default:
                    Console.WriteLine("Invalid input. Press any button to continue.");
                    Console.ReadKey();
                    break;
            }
        }

        public void SelectGameDifficulty()
        {
            Console.WriteLine("Please select a game difficulty: easy, medium, hard");
            string input = Console.ReadLine().ToLower().Trim();
            switch (input)
            {
                case "easy":
                    TotalRoomNumber = 5;
                    break;
                case "medium":
                    TotalRoomNumber = 10;
                    break;
                case "hard":
                    TotalRoomNumber = 15;
                    break;
                default:
                    Console.WriteLine("Invalid input. Defaulting to easy difficulty.");
                    TotalRoomNumber = 5;
                    break;
            }
        }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {

                Console.WriteLine("Please enter your name:");
                string name = Console.ReadLine();
                Player.Name = name;
                Player.Health = 100;
                Player.Inventory = new List<string>();

                Console.WriteLine("Welcome to the Dungeon Explorer game.");
                Console.WriteLine("You have to make it through different rooms surviving the attacks from monsters.");
                Console.WriteLine("If you make it through without losing all your health you win.");

                SelectGameDifficulty();

                playing = false;
                while (Player.Health > 0 && RoomNumber < TotalRoomNumber)
                {
                    Console.WriteLine("You are in room " + (RoomNumber + 1));


                    PlayersDecision();
                    PlayersHealth();
                    PlayersInventory();
                    DecisionToUseItem();


                }

                if (Player.Health <= 0)
                {
                    Console.WriteLine("I'm sorry but you have died to the monsters.");
                }
                else
                {
                    Console.WriteLine("You have won!");
                    Console.WriteLine("You have made it through all the rooms.");
                    Console.WriteLine("You have survived the monsters.");
                    Console.WriteLine("Congratulations");
                }
            }
        }
    }
}