using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyComponents
{
    public class FantasyTeam : IComparable
    {
        public string TeamName { get; set; }
        public string OwnerName { get; set; }
        public int FantasyYear { get; set; }

        public FantasyTeam(string teamName, string ownerName)
        {
            TeamName = teamName;
            OwnerName = ownerName;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            var otherPlayer = obj as FantasyTeam;

            if (otherPlayer != null)
                return TeamName.CompareTo(otherPlayer.TeamName);
            else
                throw new ArgumentException("Object is not a FantasyTeam");
        }
    }
}
