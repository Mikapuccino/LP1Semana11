using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public class View : IView
    {
        private readonly Controller controller;

        public View(Controller controller)
        {
            this.controller = controller;
        }

        public int ShowMenu(PlayerOrder playerOrder)
        {
            Console.WriteLine("1. Insert new player");
            Console.WriteLine("2. List all players");
            Console.WriteLine("3. List all players with a "
            + "score higher than given value");
            Console.WriteLine("4. Choose listing option");
            Console.WriteLine("0. Exit program");

            return int.Parse(Console.ReadLine());
        }

        public PlayerOrder AskPlayerOrder()
        {
            Console.WriteLine("Player order");
            Console.WriteLine($"{(int)PlayerOrder.ByScore}. Order by score");
            Console.WriteLine($"{(int)PlayerOrder.ByName}. Order by name");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByNameReverse}. Order by name (reverse)");

            return Enum.Parse<PlayerOrder>(Console.ReadLine());
        }

        public void InvalidOption()
        {
            Console.WriteLine("\nInvalid option! Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();
        }

        public void ListPlayers(IEnumerable<Player> playersToList)
        {
            foreach (Player p in playersToList)
            {
                Console.WriteLine("Name: " + p.Name);
                Console.WriteLine("Score: " + p.Score);
                Console.WriteLine("-");
            }
        }

        public (string, int) AskForPlayer()
        {
            Console.Write("Name of player: ");
            string newName = Console.ReadLine();
            Console.Write("Score of player: ");
            int newScore = int.Parse(Console.ReadLine());

            return (newName, newScore);
        }

        public int AskForMinimumScore()
        {
            Console.WriteLine();
            Console.Write("Minimum score?: ");
            return int.Parse(Console.ReadLine());
        }
    }
}