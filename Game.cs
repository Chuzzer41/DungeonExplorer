using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Policy;
using System.Text;
using System.Runtime.CompilerServices;

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
            Console.WriteLine();

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
                        if (!(Player.Health > 90))
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
                        if (!(Player.Health > 80))
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
                        Console.WriteLine(Player.Health);
                        if (!(Player.Health > 95))
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
        public void PlayersRoundOptions()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Type 'health' to view health");
                Console.WriteLine("Type 'inventory' to view inventory");
                Console.WriteLine("Type 'item' to use an item");
                Console.WriteLine("Press enter to skip");

                string input = Console.ReadLine().ToLower().Trim();
                Console.WriteLine();

                switch (input)
                {
                    case "health":
                        Console.WriteLine("Your health is " + Player.Health); break;
                    case "inventory":
                        Console.WriteLine("Your inventory contains: ");
                        Console.WriteLine(Player.InventoryContents());
                        break;
                    case "item":
                        ItemUse();
                        break;
                    case "":
                        return;
                    default:
                        Console.WriteLine("Invalid input. Press any button to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void SelectGameDifficulty()
        {
            Console.WriteLine("Please select a game difficulty: easy, medium, hard");
            string input = Console.ReadLine().ToLower().Trim();
            Console.WriteLine();

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

        public void IntroductionDescription()
        {
            Console.WriteLine("Welcome to the Dungeon Explorer.");
            Console.WriteLine("Venture into the Dungeon of Darkness an ancient, ever-changing labyrinth.");
            Console.WriteLine("Make crucial decisions that will impact your journey, with each direction opening new encounters and challenges.");
            Console.WriteLine("Battle fierce monsters that roam the rooms of the dungeon.");
            Console.WriteLine("Discover forgotten items left behind by past adventurers, each one helping you stay strong on your journey.");
            Console.WriteLine("Are you ready for whats to come.Press any key to start your adventure.");
            Console.ReadKey();
            Console.WriteLine();
        }

        public void GameRules()
        {
            Console.WriteLine("Would you like to see the rules of the game? (y or n)");
            string input = Console.ReadLine().ToLower().Trim();
            Console.WriteLine();
            switch (input)
            {
                case "y":
                    Console.WriteLine("The rules of the game are:\n");
                    Console.WriteLine("You will start on 100 health.\n");
                    Console.WriteLine("You will have to make it through a number of rooms depending on the difficulty.");
                    Console.WriteLine("Easy - 5 rooms");
                    Console.WriteLine("Medium - 10 rooms");
                    Console.WriteLine("Hard - 20 rooms\n");
                    Console.WriteLine("There are 3 different monsters.");
                    Console.WriteLine("Small monster - 1-10 damage");
                    Console.WriteLine("Regular monster - 10-20 damage");
                    Console.WriteLine("Big monster - 20-30 damage\n");
                    Console.WriteLine("You will have a chance to find items in the rooms.");
                    Console.WriteLine("Small health potion - +10 health");
                    Console.WriteLine("Large health potion - +20 health");
                    Console.WriteLine("Bandage - +5 health\n");
                    Console.WriteLine("You will have to make it through all the rooms to win.");
                    Console.WriteLine("If your health reaches 0 you will die.");
                    Console.WriteLine("Good luck.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.WriteLine();
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Invalid input. Defaulting to no.");
                    break;
            }
        }

        public void GameOver()
        {
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


        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                IntroductionDescription();

                Console.WriteLine("Please enter your name:");
                string name = Console.ReadLine();
                Player.Name = name;
                Player.Health = 100;
                Player.Inventory = new List<string>();

                GameRules();
                SelectGameDifficulty();

                playing = false;
                while (Player.Health > 0 && RoomNumber < TotalRoomNumber)
                {
                    Console.WriteLine("You are in room " + (RoomNumber + 1));

                    PlayersDecision();
                    PlayersRoundOptions();
                }

                GameOver();
            }
        }
    }
}