using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public interface IView
    {
        void StartMessage();
        bool CheckGuess(int guess, int targetNumber, int attempts);
        void EndMessage();
    }
}