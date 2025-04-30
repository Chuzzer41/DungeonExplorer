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
        private GameMap Map;
        public string DirectionChosen { get; set; } // Property to store the direction chosen by the player.

        // Constants for the items that the player can find in the rooms.
        public const string SmallHealthPotion = "Small Health Potion";
        public const string LargeHealthPotion = "Large Health Potion";
        public const string Bandage = "Bandage";
        public const string Sword = "Sword";
        public const string Bow = "Bow";
        public const string Axe = "Axe";

        // Constructor for the game class that initializes a new game object.
        public Game()
        {
            //Player = new Player("", 100, new List<string>());
            currentRoom = Room.RandomRoom();
            RoomNumber = 0;
            TotalRoomNumber = 5;
        }

        // Method that allows the player to make a decision on which direction to go.
        public void PlayersDecision()
        {
            Console.WriteLine();
            Console.WriteLine("Which direction would you like to go: forward, left, right?");

            string input = Console.ReadLine().ToLower().Trim();
            Console.WriteLine();

            DirectionChosen = input; // Sets the direction chosen by the player.

            Room nextRoom;
            switch (input)
            {
                case "forward":
                    nextRoom = Room.RandomRoom(); // Randomly generates a room for the player to enter.
                    nextRoom.GetRoomDescription(Player, ref RoomNumber); // Displays the room description.
                    ItemProbability(); // Randomly generates an item for the player to find in the room.
                    break;

                case "left":
                    nextRoom = Room.RandomRoom(); // Randomly generates a room for the player to enter.
                    nextRoom.GetRoomDescription(Player, ref RoomNumber); // Displays the room description.
                    ItemProbability(); // Randomly generates an item for the player to find in the room.
                    break;

                case "right":
                    nextRoom = Room.RandomRoom(); // Randomly generates a room for the player to enter.
                    nextRoom.GetRoomDescription(Player, ref RoomNumber); // Displays the room description.
                    ItemProbability(); // Randomly generates an item for the player to find in the room.
                    break;

                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
           
        }

        // Method that randomly generates an item for the player to find in the room.
        public void ItemProbability()
        {
            Random rnd = new Random();
            int random = rnd.Next(0, 10);
            switch (random)
            {
                case 0:
                    Player.Inventory.Add(new SmallHealthPotion()); // Adds a small health potion to the player's inventory.
                    Console.WriteLine("You have found a small health potion.");
                    break;
                case 1:
                    Player.Inventory.Add(new LargeHealthPotion()); // Adds a large health potion to the player's inventory.
                    Console.WriteLine("You have found a large health potion.");
                    break;
                case 2:
                    Player.Inventory.Add(new Bandage()); // Adds a bandage to the player's inventory.
                    Console.WriteLine("You have found a bandage.");
                    break;
                // If the random number is 3, 4, 5 or 6, the player will not find an item in the room.
                case 3:
                    Player.Inventory.Add(new Sword()); // Adds a sword to the player's inventory.
                    Console.WriteLine("You have found a sword.");
                    break;
                case 4:
                    Player.Inventory.Add(new Bow()); // Adds a bow to the player's inventory.
                    Console.WriteLine("You have found a bow.");
                    break;
                case 5:
                    Player.Inventory.Add(new Axe()); // Adds an axe to the player's inventory.
                    Console.WriteLine("You have found an axe.");
                    break;
                case 6:
                case 7:
                case 8: 
                case 9: 
                case 10: 
                case 11:
                    break;
            }
        }

        // Method that allows the player to use an item from their inventory.
        public void ItemUse()
        {
            Console.WriteLine("Do you want to use health items or equip weapons (h, w):");
            string Item = Console.ReadLine().ToLower().Trim();
            switch (Item)
            {
                case "h":
                    Console.WriteLine("Which item would you like to use: bandage, small or large health potion (b, s, l)");
                    string HealthItem = Console.ReadLine().ToLower().Trim();
                    switch (HealthItem)
                    {
                        // If the player can use a small health potion, their health will increase by 10.
                        case "s":
                            if (Player.Inventory.Contains(SmallHealthPotion))
                            {
                                if (!(Player.Health > 90))
                                {
                                    Player.Health += 10;
                                    Player.Inventory.Remove(SmallHealthPotion); // Removes the item from the player's inventory.
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

                        // If the player can use a large health potion, their health will increase by 20.
                        case "l":
                            if (Player.Inventory.Contains(LargeHealthPotion))
                            {
                                if (!(Player.Health > 80))
                                {
                                    Player.Health += 20;
                                    Player.Inventory.Remove(LargeHealthPotion); // Removes the item from the player's inventory.
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

                        // If the player can use a bandage, their health will increase by 5.
                        case "b":
                            if (Player.Inventory.Contains(Bandage))
                            {
                                Console.WriteLine(Player.Health);
                                if (!(Player.Health > 95))
                                {
                                    Player.Health += 5;
                                    Player.Inventory.Remove(Bandage); // Removes the item from the player's inventory.
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
                    break;

                case "w":
                    Console.WriteLine("Which weapon would you like to equip: sword, bow, axe (s, b, a)");
                    string Weapon = Console.ReadLine().ToLower().Trim();
                    switch (Weapon)
                    {
                        case "s":
                            if (Player.Inventory.Contains(Sword))
                            {
                                Player.equippedWeapon = new Sword();
                                Player.Inventory.Remove(Sword); // Removes the item from the player's inventory.
                                Console.WriteLine("You have equipped a sword.");
                            }
                            else
                            {
                                Console.WriteLine("You do not have a sword.");
                            }

                            break;

                        case "b":
                            if (Player.Inventory.Contains(Bow))
                            {
                                Player.equippedWeapon = new Bow();
                                Player.Inventory.Remove(Bow); // Removes the item from the player's inventory.
                                Console.WriteLine("You have equipped a bow.");
                            }
                            else
                            {
                                Console.WriteLine("You do not have a bow.");
                            }


                            break;

                        case "a":
                           if (Player.Inventory.Contains(Axe))
                            {
                                Player.equippedWeapon = new Axe();
                                Player.Inventory.Remove(Axe); // Removes the item from the player's inventory.
                                Console.WriteLine("You have equipped an axe.");
                            }
                            else
                            {
                                Console.WriteLine("You do not have an axe.");
                            }


                            break;

                        default:
                            Console.WriteLine("Invalid input. Press any button to continue.");
                            Console.ReadKey();
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("Invalid input. Press any button to continue.");
                    Console.ReadKey();
                    break;

            }
 
        }

        // Method that allows the player to view their health, inventory and allows them to use an item.
        public void PlayersRoundOptions()
        {
            while (true)
            {
                // Displays the player's options.
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
                        Console.WriteLine("Your health is " + Player.Health); break; // Displays the player's health.
                    case "inventory":
                        Console.WriteLine("Your inventory contains: ");
                        Console.WriteLine(Player.Inventory.ListContents()); // Displays the contents of the player's inventory.
                        break;
                    case "item":
                        ItemUse(); // Calls the method for the player to use an item from their inventory.
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
        // Method that allows the player to select the difficulty of the game.
        public void SelectGameDifficulty()
        {
            Console.WriteLine("Please select a game difficulty: easy, medium, hard");
            string input = Console.ReadLine().ToLower().Trim();
            Console.WriteLine();

            switch (input)
            {
                // Sets the total number of rooms based on the difficulty selected by the player.
                case "easy":
                    TotalRoomNumber = 5;
                    break;
                case "medium":
                    TotalRoomNumber = 10;
                    break;
                case "hard":
                    TotalRoomNumber = 20;
                    break;
                default:
                    Console.WriteLine("Invalid input. Defaulting to easy difficulty.");
                    TotalRoomNumber = 5;
                    break;
            }
        }

        // Method that displays the introduction to the game.
        public void IntroductionDescription()
        {
            Console.WriteLine("Welcome to the Dungeon Explorer.");
            Console.WriteLine("Venture into the Dungeon of Darkness an ancient, ever-changing labyrinth.");
            Console.WriteLine("Make crucial decisions that will impact your journey, with each direction opening new encounters and challenges.");
            Console.WriteLine("Battle fierce monsters that roam the rooms of the dungeon.");
            Console.WriteLine("Discover forgotten items left behind by past adventurers, each one helping you stay strong on your journey.");
            Console.WriteLine("Are you ready for whats to come?");
            Console.WriteLine("Press any key to start your adventure.");
            Console.ReadKey();
            Console.WriteLine();
        }

        // Method that displays the rules of the game.
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


        // Method that displays the game over messages.
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

        // Method that starts the game loop.
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                IntroductionDescription(); // Dispalys the introduction to the game.

                // Initializes the player object and sets the player's name, health and inventory.
                Console.WriteLine("Please enter your name:");
                string name = Console.ReadLine();
                Player = new Player(name, 100);
                Player.Health = 100;

                GameRules(); // Gives the user the option to view the rules of the game.
                SelectGameDifficulty(); // Allows the player to select the difficulty of the game.

                Map = new GameMap(TotalRoomNumber); // Initializes the game map.


                // Game loop that continues until the player dies or passes the final room.
                playing = false;
                while (Player.Health > 0 && RoomNumber < TotalRoomNumber)
                {
                    Console.WriteLine("You are in room " + (RoomNumber + 1));

                    string CorrectDirection = Map.GetCorrectDirection(RoomNumber); // Gets the room description from the map.
                    PlayersDecision(); // Allows the player to make a decision on which direction to go.

                    if (CorrectDirection == DirectionChosen)
                    {
                        Console.WriteLine("You have chosen the correct direction.");
                        RoomNumber++; // Increments the room number.
                    }
                    else
                    {
                        Console.WriteLine("You have chosen the wrong direction.");
                        Console.WriteLine("You must go back and try a differnt direction.");
                    }

                    PlayersRoundOptions(); // Allows the player to view their health, inventory and use an item.
                }

                GameOver(); // Displays the game over messages.
            }
        }
    }
}