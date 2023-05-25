using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public interface IView
    {
        int ShowMenu(PlayerOrder playerOrder);
        void InvalidOption();
        void ListPlayers(IEnumerable<Player> players);
        (string, int) AskForPlayer();
        int AskForMinimumScore();
        PlayerOrder AskPlayerOrder();
    }
}