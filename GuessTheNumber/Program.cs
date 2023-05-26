using System;

namespace GuessTheNumber
{
    public class Program
    {
        private static void Main()
        {
            Controller controller = new Controller();
            Model model = new Model();
            IView view = new View(controller);

            controller.Run(view, model);
        }
    }
}