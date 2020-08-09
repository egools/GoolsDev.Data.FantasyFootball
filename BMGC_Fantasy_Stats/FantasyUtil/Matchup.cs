using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static FantasyComponents.Util;

namespace FantasyComponents
{
    [Table("Matchup", Schema = "bmgc")]
    public class Matchup
    {
        public int MatchupID { get; set; }
        public Season Season { get; set; }
    }

    [Table("MatchupPlayer", Schema = "bmgc")]
    public class MatchupPlayer : IComparable<MatchupPlayer>
    {
        public int MatchupPlayerID;
        public MatchupRoster Roster { get; }
        public NFLPlayer NFLPlayer { get; set; }
        public StatBlock Stats { get; set; }
        public float ProjectedPoints { get; set; }
        public float ActualPoints { get; set; }
        public FantasyPosition MatchupPosition { get; set; }

        public int CompareTo(MatchupPlayer other)
        {
            if (other == null)
                return 1;
            else
                return ActualPoints.CompareTo(other.ActualPoints);
        }
    }

    [Table("MatchupPlayer", Schema = "bmgc")]
    public class StatBlock
    {
        public short MatchupPlayerID;
        public short PassingYards;
        public short PassingTDs;
        public short PassingINTs;
        public short RushingYards;
        public short RushingTDs;
        public short ReceivingYards;
        public short ReceivingTDs;
        public short ReturnTDs;
        public short TwoPoint;
        public short FumblesLost;
        public short FieldGoals0_19;
        public short FieldGoals20_29;
        public short FieldGoals30_39;
        public short FieldGoals40_49;
        public short FieldGoals50plus;
        public short PATs;
        public string PointsAgainst;
        public short Sacks;
        public short Safeties;
        public short DefensiveInterceptions;
        public short FumbleRecoveries;
        public short DefensiveTDs;
        public short BlockedKicks;
        public short SpecialTeamsTDs;

    }

    [Table("MatchupRoster", Schema = "bmgc")]
    public class MatchupRoster
    {
        public int MatchupRosterID;
        public Matchup Matchup { get;  }
        public Dictionary<FantasyPosition, int> Starters;
        public List<int> Bench;
    }
}
