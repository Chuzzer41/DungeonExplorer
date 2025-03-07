using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        private Player Player;
        private int RoomNumber;
        private static Random rnd = new Random();
        public Game()
        {
            Player = new Player("", 100, new System.Collections.Generic.List<string>());
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

        public void Start()
        {
            bool playing = true;
            while (playing)
            {

                Console.WriteLine("Enter your name:");
                string name = Console.ReadLine();
                Player.Name = name;
                player.Health = 100;
                player.Inventory = new System.Collections.Generic.List<string>();

                Console.WriteLine("Add introduction to game");

                playing = false;
                while (player.Health > 0 && RoomNumber < 10)
                {
                    Console.WriteLine("You are in room " + RoomNumber);
                    PlayersDecision();


                }

                if (player.Health <= 0)
                {
                    Console.WriteLine("You have died.");
                }
                else
                {
                    Console.WriteLine("You have won!");
                }
            }
        }
    }
}