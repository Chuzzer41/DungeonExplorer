using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class GameMap
    {
        // This class represents the game map and contains the logic for the rooms and their correct directions.
        private List<string> CorrectDirections;
        private static readonly string[] Directions = { "forward", "left", "right" };
        private Random random;

        // Constructor for the GameMap class
        public GameMap(int roomNumber)
        {
            // Initializes the list of correct directions for the specified number of rooms
            CorrectDirections = new List<string>();
            random = new Random();

            for (int i = 0; i < roomNumber; i++)
            {
                CorrectDirections.Add(Directions[random.Next(Directions.Length)]);
            }
        }

        // Method to get the correct direction for a specific room number
        public string GetCorrectDirection(int roomNumber)
        {
            if (roomNumber >= 0 && roomNumber < CorrectDirections.Count)
            {
                return CorrectDirections[roomNumber];
            }
            else
            {
                throw new ArgumentOutOfRangeException("roomNumber", "Room number is out of range.");
            }
        }
    }
}
