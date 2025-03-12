using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tries to run the game
            try
            {
                // Creates a new instance of the Game class and starts the game
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
