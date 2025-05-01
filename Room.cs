using System;

namespace DungeonExplorer
{
    public class Room
    {
        private Monster monster;

        private static Random rnd = new Random();

        // Constructor for the Room class
        public Room(Monster monster)
        {
            this.monster = monster;
        }

        // Randomly generates a room with a monster or empty room
        public static Room RandomRoom()
        {
            int random = rnd.Next(0, 14);
            switch (random)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return new Room(new SmallMonster("Small Monster", 10));
                case 4:
                case 5:
                case 6:
                    return new Room(new RegularMonster("Regular Monster", 20));
                case 7:
                    return new Room(new LargeMonster("Large Monster", 30));
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    return new Room(null);
                default:
                    return new Room(null);
            }
        }


        // Method to get the room description and handle monster encounters
        public void GetRoomDescription(Player player, ref int RoomNumber)
        {
            RoomDescription(); // Calls the RoomDescription method to display a description of the room

            // Checks if the room contains a monster
            if (monster != null)
            {
                Console.WriteLine("");
                Console.WriteLine($"A {monster.Name} blocks your way.");

                // Loops until the monster or player is defeated
                while (monster.Health > 0 && player.Health > 0)
                {
                    // Displays the current health of the player and monster
                    Console.WriteLine("");
                    Console.WriteLine($"You have {player.Health} health left.");
                    Console.WriteLine($"The {monster.Name} has {monster.Health} health left.");

                    Console.WriteLine("Press any key to attack the monster.");
                    Console.ReadKey();
                    Console.WriteLine("");

                    // Player attacks the monster
                    player.Attack(monster);

                    // Checks if the monster is defeated
                    if (monster.Health <= 0)
                    {
                        // If the monster is defeated, it drops loot and displays a message
                        Console.WriteLine($"You defeated the {monster.Name}!");
                        Console.WriteLine("");
                        break;
                    }
                    else
                    {
                        // If the monster is still alive, it attacks the player
                        monster.Attack(player);
                        if (player.Health <= 0)
                        {
                            Console.WriteLine("You have been defeated!");
                            break;
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("You pass through an empty room.");
            }
        }





        // Method to display a description of the room based on the type of room
        public void RoomDescription()
        {

            Random rnd = new Random();

            if (monster is SmallMonster)
            {
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
            }
            else if (monster is RegularMonster)
            {
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
                        Console.WriteLine("A imposing monster approaches, its claws scraping the floor.");
                        break;
                    case 5:
                        Console.WriteLine("The floor trembles as a powerful creature steps into the light, ready to attack.");
                        break;
                    default:
                        break;
                }
            }
            else if (monster is LargeMonster)
            {
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
            }
            else
            {
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
            }
        
        }
    }
}