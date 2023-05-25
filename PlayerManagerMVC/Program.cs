using System;
using System.Collections.Generic;

namespace PlayerManagerMVC
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The list of all players.
        /// </summary>
        private List<Player> playerList;

        /// <summary>
        /// Program begins here.
        /// </summary>
        private static void Main()
        {
            // Create a new instance of the player listing program
            Program prog = new Program();
            // Start the program instance
            prog.Start();
        }

        /// <summary>
        /// Creates a new instance of the player listing program.
        /// </summary>
        private Program()
        {
            // Initialize the player list with two players using collection
            // initialization syntax
            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };

            playerList.Sort();
        }

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        private void Start()
        {
            // We keep the user's option here
            string option;

            // Main program loop
            do
            {
                // Show menu and get user option
                ShowMenu();
                option = Console.ReadLine();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        ChooseListingOption();
                        break;
                    case "5":
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                        break;
                }

                // Wait for user to press a key...
                Console.Write("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine("\n");

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "5");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine("1. Insert new player");
            Console.WriteLine("2. List all players");
            Console.WriteLine("3. List all players with a "
            + "score higher than given value");
            Console.WriteLine("4. Choose listing option");
            Console.WriteLine("5. Exit program");
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            Console.Write("Name of player: ");
            string newName = Console.ReadLine();
            Console.Write("Score of player: ");
            int newScore = int.Parse(Console.ReadLine());

            Player newPlayer = new Player(newName, newScore);
            playerList.Add(newPlayer);
            playerList.Sort();

            Console.WriteLine($"{newName} successfully added");
        }

        /// <summary>
        /// Show all players in a list of players. This method can be static
        /// because it doesn't depend on anything associated with an instance
        /// of the program. Namely, the list of players is given as a parameter
        /// to this method.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private static void ListPlayers(IEnumerable<Player> playersToList)
        {
            foreach (Player p in playersToList)
            {
                Console.WriteLine("Name: " + p.Name);
                Console.WriteLine("Score: " + p.Score);
                Console.WriteLine("-");
            }
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            Console.Write("Value to beat: ");
            int newValue = int.Parse(Console.ReadLine());

            IEnumerable<Player> validPlayers = 
            GetPlayersWithScoreGreaterThan(newValue);

            foreach (Player p in validPlayers)
            {
                Console.WriteLine("Name: " + p.Name);
                Console.WriteLine("Score: " + p.Score);
                Console.WriteLine("-");
            }
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            List<Player> validPlayers = new List<Player>();
            
            foreach (Player p in playerList)
            {
                if (p.Score > minScore)
                {
                    yield return p;
                }
            }

            yield break;
        }

        private void ChooseListingOption()
        {
            IComparer<Player> alphaComp = new CompareByName(true);
            IComparer<Player> antiAlphaComp = new CompareByName(false);
            
            Console.WriteLine("1. List by score");
            Console.WriteLine("2. List by alphabetical order");
            Console.WriteLine("3. List by reverse alphabetical order");

            string listingOption = Console.ReadLine();

            // Determine the option specified by the user and act on it
            switch (listingOption)
            {
                case "1":
                    playerList.Sort();
                    break;
                case "2":
                    playerList.Sort(alphaComp);
                    break;
                case "3":
                    playerList.Sort(antiAlphaComp);
                    break;
            }
        }
    }
}