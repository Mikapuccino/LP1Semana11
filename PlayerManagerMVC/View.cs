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

        private void ShowMenu(PlayerOrder playerOrder)
        {
            Console.WriteLine("1. Insert new player");
            Console.WriteLine("2. List all players");
            Console.WriteLine("3. List all players with a "
            + "score higher than given value");
            Console.WriteLine("4. Choose listing option");
            Console.WriteLine("5. Exit program");

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
    }
}