using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class Controller
    {
        public void Run(IView view, Model model)
        {
            int targetNumber = model.Initialize();
            int guess;
            int attempts = 0;
            bool guessedCorrectly = false;

            view.StartMessage();

            // Game loop
            while (!guessedCorrectly)
            {
                Console.Write("Take a guess: ");
                guess = Convert.ToInt32(Console.ReadLine());
                attempts++;

                guessedCorrectly = 
                view.CheckGuess(guess, targetNumber, attempts);
            }

            view.EndMessage();
        }
    }
}