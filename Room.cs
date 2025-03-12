using System;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        // Constants for the different types of rooms
        public const string SmallMonster = "Small Monster";
        public const string RegularMonster = "Regular Monster";
        public const string BigMonster = "Big Monster";
        public const string empty = "empty";

        private static Random rnd = new Random();

        // Getters and Setters for the description of the room
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // Constructor for the Room class and initializes the description of the room
        public Room(string description)
        {
            Description = description;
        }

        // Method to generate a random room with differnet probabilities
        public static Room RandomRoom()
        {
            int random = rnd.Next(0, 7);
            switch (random)
            {
                case 0:
                case 1:
                    return new Room(SmallMonster);
                case 2:
                case 3:
                    return new Room(RegularMonster);
                case 4:
                    return new Room(BigMonster);
                case 5:
                case 6:
                    return new Room(empty);
                default:
                    return new Room(empty);
            }
        }

        // Method to get the description of the room and perform an action based on the description
        public void GetRoomDescription(Player player, ref int RoomNumber)
        {
            switch (Description)
            {
                // If the room contains a small monster, the player battles the monster and takes damage
                case SmallMonster:

                    RoomDescription(); // Calls the RoomDescription method to display a description of the room
                    Console.WriteLine("You battle a small monster.");
                    int damage = rnd.Next(1, 10);
                    player.Health -= damage;
                    RoomNumber++;
                    break;

                // If the room contains a regular monster, the player battles the monster and takes damage
                case RegularMonster:

                    RoomDescription(); // Calls the RoomDescription method to display a description of the room
                    Console.WriteLine("You battle a regular monster.");
                    int damage2 = rnd.Next(10,20);
                    player.Health -= damage2;
                    RoomNumber++;
                    break;

                // If the room contains a big monster, the player battles the monster and takes damage
                case BigMonster:

                    RoomDescription(); // Calls the RoomDescription method to display a description of the room
                    Console.WriteLine("You battle a big monster.");
                    int damage3 = rnd.Next(20, 30);
                    player.Health -= damage3;
                    RoomNumber++;
                    break;

                // If the room is empty, the player passes through the room
                case empty:

                    RoomDescription(); // Calls the RoomDescription method to display a description of the room
                    Console.WriteLine("You pass through an empty room.");
                    RoomNumber++;
                    break;

                default:
                    Console.WriteLine("Error");
                    break;

            }

        }

        // Method to display a description of the room based on the type of room
        public void RoomDescription()
        {

            Random rnd = new Random();

            switch (Description)
            {
                // If the room contains a small monster, display a random description of the room with a small monster
                case SmallMonster:
                    int random1 = rnd.Next(0, 6);
                    switch (random1)
                    {
                        case 0:
                            Console.WriteLine("A small creature scuttle from the shadows, its eyes glowing in the dark.");
                            break;
                        case 1:
                            Console.WriteLine("A tiny, hissing monster rushes at you from the corner.");
                            break;
                        case 2:
                            Console.WriteLine("A small, snarling creature burst forth, quick and relentless.");
                            break;
                        case 3:
                            Console.WriteLine("A tiny, venomous beast crawl from cracks, its fangs glinting in the dim light.");
                            break;
                        case 4:
                            Console.WriteLine("You spot the glowing eyes of tiny a beast as it dart from corner to corner.");
                            break;
                        case 5:
                            Console.WriteLine("A quick-footed creature scurry across the floor, ready to strike.");
                            break;
                        default:
                            break;
                    }
                    break;

                // If the room contains a regular monster, display a random description of the room with a regular monster
                case RegularMonster:
                    int random2 = rnd.Next(0, 6);
                    switch (random2)
                    {
                        case 0:
                            Console.WriteLine("The growl of something heavy echoes as a hulking beast emerges.");
                            break;
                        case 1:
                            Console.WriteLine("The sound of claws scraping against stone grows louder as a beast appears.");
                            break;
                        case 2:
                            Console.WriteLine("A beast charges from the darkness, powerful and ready to strike.");
                            break;
                        case 3:
                            Console.WriteLine("You hear heavy footsteps before a beast steps into view.");
                            break;
                        case 4:
                            Console.WriteLine("A large, imposing monster approaches, its claws scraping the floor.");
                            break;
                        case 5:
                            Console.WriteLine("The floor trembles as a powerful creature steps into the light, ready to attack.");
                            break;
                        default:
                            break;
                    }
                    break;

                // If the room contains a big monster, display a random description of the room with a big monster
                case BigMonster:
                    int random3 = rnd.Next(0, 6);
                    switch (random3)
                    {
                        case 0:
                            Console.WriteLine("The ground shakes as a massive beast steps into view, its roar deafening.");
                            break;
                        case 1:
                            Console.WriteLine("The room trembles as an enormous creature lumbers toward you.");
                            break;
                        case 2:
                            Console.WriteLine("A massive shadow blocks your path as a gigantic beast approaches.");
                            break;
                        case 3:
                            Console.WriteLine("A huge monster emerges, its massive claws scraping the stone.");
                            break;
                        case 4:
                            Console.WriteLine("The air grows heavy as a colossal monster makes its presence known, its steps shaking the ground.");
                            break;
                        case 5:
                            Console.WriteLine("A giant beast steps forward, its size and power overwhelming.");
                            break;
                        default:
                            break;
                    }
                    break;

                // If the room is empty, display a random description of the empty room
                case empty:
                    int random4 = rnd.Next(0, 6);
                    switch (random4)
                    {
                        case 0:
                            Console.WriteLine("The room is silent, empty, and the air is heavy with dust.");
                            break;
                        case 1:
                            Console.WriteLine("The space is eerily still, the faint echo of your footsteps the only sound.");
                            break;
                        case 2:
                            Console.WriteLine("Cold air stirs in the empty chamber, but there’s no sign of life.");
                            break;
                        case 3:
                            Console.WriteLine("The walls are bare, and only the sound of dripping water fills the silence.");
                            break;
                        case 4:
                            Console.WriteLine("The floor is bare and cracked, with nothing but the faint sound of your breathing.");
                            break;
                        case 5:
                            Console.WriteLine("You find yourself in a vacant chamber, the air thick with dust.");
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}