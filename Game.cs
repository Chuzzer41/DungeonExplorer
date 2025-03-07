using System;
using System.Media;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        private Player Player;
        private int RoomNumber;
        public Game()
        {
            Player = new Player("", 100, new List<string>());
            currentRoom = Room.RandomRoom();
            RoomNumber = 0;
        }

        public void PlayersDecision()
        {
            Console.WriteLine("Which direction would you like to go: forward, left, right?");

            string input = Console.ReadLine().ToLower();

            Room nextRoom;
            switch (input)
            {
                case "forward":
                    nextRoom = Room.RandomRoom();
                    nextRoom.GetRoomDescription(Player, ref RoomNumber);
                    break;

                case "left":
                    nextRoom = Room.RandomRoom();
                    nextRoom.GetRoomDescription(Player, ref RoomNumber);
                    break;

                case "right":
                    nextRoom = Room.RandomRoom();
                    nextRoom.GetRoomDescription(Player, ref RoomNumber);
                    break;

                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
           
        }

        public void PlayersHealth()
        {
            Console.WriteLine("Would you like to see your health? yes or no");
            string input = Console.ReadLine().ToLower();
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

                playing = false;
                while (Player.Health > 0 && RoomNumber < 5)
                {
                    Console.WriteLine("You are in room " + (RoomNumber + 1));


                    PlayersDecision();
                    PlayersHealth();


                }

                if (Player.Health <= 0)
                {
                    Console.WriteLine("I'm sorry but you have died to the monsters.");
                }
                else
                {
                    Console.WriteLine("You have won! Con");
                }
            }
        }
    }
}