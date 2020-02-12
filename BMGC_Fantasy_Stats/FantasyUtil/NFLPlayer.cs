using System;
using System.Collections.Generic;
using System.Text;
using static FantasyComponents.Util;

namespace FantasyComponents
{
    public class NFLPlayer : IComparable
    {
        public string ID { get; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string NFLTeam { get; set; }
        public NFLPosition NFLPosition { get; set; }

        public NFLPlayer(string id)
        {
            ID = id;
        }
        public bool IsEligible(FantasyPosition position)
        {
            if ((int)position / (int)NFLPosition == 10)
                return true;
            else if (position == FantasyPosition.FLEX &&
                    (NFLPosition == NFLPosition.RB ||
                    NFLPosition == NFLPosition.WR ||
                    NFLPosition == NFLPosition.TE))
                return true;
            else return false;
        }

        public int CompareTo(object obj)
        {
            return ID.CompareTo(obj);
        }
    }
}
