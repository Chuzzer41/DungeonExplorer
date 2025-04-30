using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{

    // Test development 2 branch
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tries to run the game
            try
            {
                // Asks the user if they want to run the tests
                Console.WriteLine("Would you like to use the test class and run through some tests? (y or n) ");
                string answer = Console.ReadLine().ToLower().Trim();
                
                switch(answer)
                {
                    case "y":
                        // Runs the tests from the Testing class
                        Console.WriteLine("Running tests: ");
                        Testing.PlayerTests();
                        Testing.InventoryTests();
                        Testing.RoomTests();

                        break;
                    case "n":
                        Console.WriteLine("Okay, straight to the game.");
                        break;
                    default:
                        // If the user enters an invalid input, it defaults to skipping the tests
                        Console.WriteLine("Invalid input defaulting to skipping tests.");
                        break;
                }

                // Creates a new instance of the Game class and starts the game
                Console.WriteLine("\n\n\n");
                Game game = new Game();
                game.Start();


            }

            // Catches any exceptions that are thrown and displays the error message
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured: " + ex.Message);
            }

            // Runs the code in the finally block after the try block has finished
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
