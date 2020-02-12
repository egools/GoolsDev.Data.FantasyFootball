using System;
using System.Collections.Generic;

namespace FantasyComponents
{
    public class FantasySeason
    {
        public int Year { get; set; }
        public List<FantasyMatchup> Matchups { get; }
        public HashSet<string> OwnerNames { get; }
        public Dictionary<string, NFLPlayer> Players { get; }

        public FantasySeason(int year)
        {
            Year = year;
            Matchups = new List<FantasyMatchup>();
            OwnerNames = new HashSet<string>();
        }

        public void AddMatchup(FantasyMatchup matchup)
        {
            Matchups.Add(matchup);
        }
    }
}
