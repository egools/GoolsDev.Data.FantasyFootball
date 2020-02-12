using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FantasyComponents.Util;

namespace FantasyComponents
{
    public class FantasyTeam : IComparable
        {
            public string Week { get; set; }
            public List<MatchupPlayer> Starters { get; set; }
            public List<MatchupPlayer> Bench { get; set; }
            public float Score => Starters.Sum(p => p.ActualPoints);

            public FantasyTeam(string week)
            {
                Week = week;
                Starters = new List<MatchupPlayer>();
                Bench = new List<MatchupPlayer>();
            }

            public void AddPlayer(MatchupPlayer player)
            {
                if (player.MatchupPosition == FantasyPosition.BN)
                    Bench.Add(player);
                else
                {
                    if (player.MatchupPosition == FantasyPosition.RB1 && Starters.Count(s => s.MatchupPosition == FantasyPosition.RB1) > 0)
                        player.MatchupPosition = FantasyPosition.RB2;
                    else if (player.MatchupPosition == FantasyPosition.WR1 && Starters.Count(s => s.MatchupPosition == FantasyPosition.WR1) > 0)
                        player.MatchupPosition = FantasyPosition.WR2;
                    Starters.Add(player);
                }
            }

            public List<MatchupPlayer> IdealTeam()
            {
                var tempTeam = new List<MatchupPlayer>();
                var roster = Starters.Union(Bench).ToList();
                foreach (var position in ValidRoster)
                {
                    var player = roster.Where(p => p.Player.IsEligible(position)).Max();
                    tempTeam.Add(player);
                    roster.Remove(player);
                }

                return tempTeam;
            }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                var otherTeam = obj as FantasyTeam;

                if (otherTeam != null)
                    return Score.CompareTo(otherTeam.Score);
                else
                    throw new ArgumentException("Object is not a FantasyTeam");
            }
        }
}
