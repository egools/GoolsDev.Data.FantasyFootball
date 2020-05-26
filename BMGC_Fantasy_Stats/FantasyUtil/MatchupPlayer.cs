using System;
using System.Collections.Generic;
using System.Text;
using static FantasyComponents.Util;

namespace FantasyComponents
{
    public class MatchupPlayer : IComparable
    {
        public MatchupPlayer(int id)
        {
            NFLPlayerID = id;
        }

        public int MatchupPlayerID { get; }
        public int MatchupRosterID { get; set; }
        public int NFLPlayerID { get; set; }
        public FantasyPosition MatchupPosition { get; set; }
        public float ProjectedPoints { get; set; }
        public float ActualPoints { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            var otherPlayer = obj as MatchupPlayer;

            if (otherPlayer != null)
                return ActualPoints.CompareTo(otherPlayer.ActualPoints);
            else
                throw new ArgumentException("Object is not a MatchupPlayer");
        }
    }
}
