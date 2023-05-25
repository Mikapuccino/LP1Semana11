using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public class Controller
    {
        private List<Player> playerList;
        private IView view;
        private IComparer<Player> compareByName;
        private IComparer<Player> compareByNameReverse;
        private PlayerOrder playerOrder;

        public Controller(List<Player> list)
        {
            playerList = list;

            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);
            playerOrder = PlayerOrder.ByScore;
        }

        public void Run(IView view)
        {
            int input;
            this.view = view;
            do
            {
                input = view.ShowMenu(playerOrder);
                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        InsertPlayer();
                        break;
                    case 2:
                        SortPlayers();
                        view.ShowPlayers(playerList);
                        break;
                    case 3:
                        SortPlayers();
                        ShowPlayersWithScore();
                        break;
                    case 4:
                        ChangePlayerOrder();
                        break;
                    default:
                        view.InvalidOption();
                        break;
                }
            }
            while (input != 0);
        }

        private void ChangePlayerOrder()
        {
            do
            {
                playerOrder = view.AskPlayerOrder();
                if (playerOrder < PlayerOrder.ByScore
                    || playerOrder > PlayerOrder.ByNameReverse)
                {
                    view.InvalidOption();
                }
                else
                {
                    break;
                }
            }
            while (true);
        }
        private void SortPlayers()
        {
            switch (playerOrder)
            {
                case PlayerOrder.ByScore:
                    list.Sort();
                    break;
                case PlayerOrder.ByName:
                    list.Sort(compareByName);
                    break;
                case PlayerOrder.ByNameReverse:
                    list.Sort(compareByNameReverse);
                    break;
            }
        }

        private void InsertPlayer()
        {
            (string name, int score) = view.AskForPlayer();

            Player p = new Player(name, score);

            list.Add(p);
        }

        private void ShowPlayersWithScore()
        {
            int minScore = view.AskForMinimumScore();

            IEnumerable<Player> players =
                GetPlayersWithScoreGreaterThan(minScore);

            view.ListPlayers(players);
        }

        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (Player p in list)
            {
                if (p.Score > minScore)
                    yield return p;
            }
        }
    }
}