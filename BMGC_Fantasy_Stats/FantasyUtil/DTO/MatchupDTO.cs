using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyComponents.DTO
{
    public class MatchupDTO
    {
        public string LeagueName { get; set; }
        public string SeasonYear { get; set; }
        public string Week { get; set; }
        public TeamDTO LeftTeam { get; set; }
        public TeamDTO RightTeam { get; set; }
    }
    public class TeamDTO
    {
        public string Manager { get; set; }
        public string TeamName { get; set; }
        public List<PlayerDTO> Players { get; set; }
    }

    public class PlayerDTO
    {
        public string FullName { get; set; }
        public int PlayerId { get; set; }
        public string MatchupPosition { get; set; }
        public double? PointsScored { get; set; }
        public double ProjectedPoints { get; set; }
        public string ShortName { get; set; }
        public List<StatDTO> Stats { get; set; }
    }
    public class StatDTO
    {
        public string StatText { get; set; }
        public double Points { get; set; }
    }
}
