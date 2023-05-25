using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class Controller
    {
        public void Run(IView view)
        {
            // Generate a random number
            Random random = new Random();

            // Generate a number between 1 and 100
            int targetNumber = random.Next(1, 101);

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

                if (guess == targetNumber)
                {
                    Console.WriteLine(
                        "Congratulations! You guessed the number correctly!");
                    Console.WriteLine("Number of attempts: " + attempts);
                    guessedCorrectly = true;
                }
                else if (guess < targetNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else
                {
                    Console.WriteLine("Too high! Try again.");
                }
            }

            Console.WriteLine("Thank you for playing Guess the Number!");
        }
    }
}