using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class View : IView
    {
        private readonly Controller controller;

        public View(Controller controller)
        {
            this.controller = controller;
        }

        public void StartMessage()
        {
            Console.WriteLine("Welcome to Guess the Number!");
            Console.WriteLine("I have chosen a number between 1 and 100.");
        }

        public bool CheckGuess(int guess, int targetNumber, int attempts)
        {
            if (guess == targetNumber)
                {
                    Console.WriteLine(
                        "Congratulations! You guessed the number correctly!");
                    Console.WriteLine("Number of attempts: " + attempts);
                    return true;
                }
                else if (guess < targetNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                    return false;
                }
                else
                {
                    Console.WriteLine("Too high! Try again.");
                    return false;
                }
        }
    }
}