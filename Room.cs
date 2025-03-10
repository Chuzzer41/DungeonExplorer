using System;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        public const string SmallMonster = "Small Monster";
        public const string RegularMonster = "Regular Monster";
        public const string BigMonster = "Big Monster";
        public const string empty = "empty";
        private static Random rnd = new Random();


        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public Room(string description)
        {
            Description = description;
        }

        public static Room RandomRoom()
        {
            int random = rnd.Next(0, 8);
            switch (random)
            {
                case 0:
                case 1:
                case 2:
                    return new Room(SmallMonster);
                case 3:
                case 4:
                    return new Room(RegularMonster);
                case 5:
                    return new Room(BigMonster);
                case 6:
                case 7:
                    return new Room(empty);
                default:
                    return new Room(empty);
            }
        }

        public void GetRoomDescription(Player player, ref int RoomNumber)
        {
            switch (Description)
            {
                case SmallMonster:
                    
                    Console.WriteLine("You see a small monster in the room.");
                    int damage = rnd.Next(1, 10);
                    player.Health -= damage;
                    RoomNumber++;
                    break;

                case RegularMonster:
                    Console.WriteLine("You see a regular monster in the room.");
                    int damage2 = rnd.Next(10,20);
                    player.Health -= damage2;
                    RoomNumber++;
                    break;

                case BigMonster:
                    Console.WriteLine("You see a big monster in the room.");
                    int damage3 = rnd.Next(20, 30);
                    player.Health -= damage3;
                    RoomNumber++;
                    break;

                case empty:
                    Console.WriteLine("The room is empty.");
                    RoomNumber++;
                    break;

                default:
                    Console.WriteLine("Error");
                    break;

            }

        }
    }
}