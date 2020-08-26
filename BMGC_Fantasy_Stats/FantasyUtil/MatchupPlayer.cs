using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FantasyComponents.Util;

namespace FantasyComponents
{
    [Table("MatchupPlayers")]
    public class MatchupPlayer : IComparable<MatchupPlayer>
    {
        [Key]
        public int MatchupPlayerID;

        public int MatchupRosterId { get; }
        public MatchupRoster Roster { get; }
        public int NFLPlayerId { get; }
        public NFLPlayer NFLPlayer { get; set; }

        public float ProjectedPoints { get; set; }
        public float ActualPoints { get; set; }
        public FantasyPosition MatchupPosition { get; set; }
        public string StatBlock { get; set; }

        public int CompareTo(MatchupPlayer other)
        {
            if (other == null)
                return 1;
            else
                return ActualPoints.CompareTo(other.ActualPoints);
        }
    }

    //[Table("MatchupPlayers")]
    //public class StatBlock
    //{
    //    public short MatchupPlayerID;
    //    public short PassingYards;
    //    public short PassingTDs;
    //    public short PassingINTs;
    //    public short RushingYards;
    //    public short RushingTDs;
    //    public short ReceivingYards;
    //    public short ReceivingTDs;
    //    public short ReturnTDs;
    //    public short TwoPoint;
    //    public short FumblesLost;
    //    public short FieldGoals0_19;
    //    public short FieldGoals20_29;
    //    public short FieldGoals30_39;
    //    public short FieldGoals40_49;
    //    public short FieldGoals50plus;
    //    public short PATs;
    //    public string PointsAgainst;
    //    public short Sacks;
    //    public short Safeties;
    //    public short DefensiveInterceptions;
    //    public short FumbleRecoveries;
    //    public short DefensiveTDs;
    //    public short BlockedKicks;
    //    public short SpecialTeamsTDs;

    //}
}
