using System;
using System.Collections.Generic;

namespace PlayerManagerMVC
{
    public class Program
    {
        private static void Main()
        {
            List<Player> list = new List<Player>()
            {
                new Player("Pedro", 50),
                new Player("Verde", 42),
            };

            Controller controller = new Controller(list);

            IView view = new View(controller);

            controller.Run(view);
        }
    }
}