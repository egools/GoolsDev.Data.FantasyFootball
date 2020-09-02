using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyComponents.DTO
{
    public class MatchupDTO : BaseDTO
    {
        public string Week { get; set; }
        public TeamDTO LeftTeam { get; set; }
        public TeamDTO RightTeam { get; set; }
    }
    public class TeamDTO
    {
        [JsonProperty(PropertyName ="Manager")]
        public string ManagerName { get; set; }
        public string YahooManagerId { get; set; }
        public string TeamName { get; set; }
        public List<PlayerDTO> Players { get; set; }
        public float ActualScore => Players.Where(p => p.MatchupPosition != "BN").Sum(p => p.PointsScoredNonNull);
        public float ProjectedScore => Players.Where(p => p.MatchupPosition != "BN").Sum(p => p.ProjectedPointsNonNull);
    }

    public class PlayerDTO
    {
        public string FullName { get; set; }
        public int PlayerId { get; set; }
        public string MatchupPosition { get; set; }
        public float PointsScoredNonNull { get { return PointsScored ?? 0; } set { PointsScored = value; } }
        public float ProjectedPointsNonNull { get { return ProjectedPoints ?? 0; } set { ProjectedPoints = value; } }
        public float? PointsScored { get; set; }
        public float? ProjectedPoints { get; set; }
        public string ShortName { get; set; }
        public List<StatDTO> Stats { get; set; }
    }
    public class StatDTO

    {
        public string StatText { get; set; }
        public float Points { get; set; }
    }
}
