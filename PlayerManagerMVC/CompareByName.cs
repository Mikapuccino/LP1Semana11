using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManager4
{
    public class CompareByName : IComparer<Player>
    {
        public bool Order { get; }

        public CompareByName(bool order)
        {
            Order = order;
        }

        public int Compare(Player first, Player second)
        {
            if (Order)
            {
                return first.Name.CompareTo(second.Name);
            }

            else if (!Order)
            {
                return -(first.Name.CompareTo(second.Name));
            }

            else
            {
                return 0;
            }
        }
    }
}