using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FantasyComponents.Util;

namespace FantasyComponents
{
    public class MatchupRoster
    {
        public int MatchupRosterID { get; }
        public string OwnerID { get; set; }
        public string Week { get; set; }
        public Dictionary<FantasyPosition, int> Starters { get; }
        public List<int> Bench { get; }

        public MatchupRoster(string week)
        {
            Week = week;
            Starters = new Dictionary<FantasyPosition, int>();
            Bench = new List<int>();
        }

        public void AddPlayer(MatchupPlayer player)
        {
            if (player.MatchupPosition == FantasyPosition.BN)
                Bench.Add(player.NFLPlayerID);
            else
            {
                if (player.MatchupPosition == FantasyPosition.RB1 && Starters.ContainsKey(FantasyPosition.RB1))
                    player.MatchupPosition = FantasyPosition.RB2;
                else if (player.MatchupPosition == FantasyPosition.WR1 && Starters.ContainsKey(FantasyPosition.WR1))
                    player.MatchupPosition = FantasyPosition.WR2;

                Starters.Add(player.MatchupPosition, player.NFLPlayerID);
            }
        }

        //public List<MatchupPlayer> IdealTeam()
        //{
        //    var tempTeam = new List<MatchupPlayer>();
        //    foreach (var position in ValidRoster)
        //    {
        //        var player = Roster.Where(p => p.Player.IsEligible(position)).Max();
        //        tempTeam.Add(player);
        //        roster.Remove(player);
        //    }

        //    return tempTeam;
        //}
    }
}
