using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class GameMap
    {
        private List<string> CorrectDirections;
        private static readonly string[] Directions = { "forward", "left", "right" };
        private Random random;


        public GameMap(int roomNumber)
        {
            CorrectDirections = new List<string>();
            random = new Random();

            for (int i = 0; i < roomNumber; i++)
            {
                CorrectDirections.Add(Directions[random.Next(Directions.Length)]);
            }
        }

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
