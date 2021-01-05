using FantasyComponents;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace FantasyParser.DTO
{
    public class MatchupDto : BaseDto
    {
        public string Week { get; set; }
        public TeamDto LeftTeam { get; set; }
        public TeamDto RightTeam { get; set; }
    }
    public class TeamDto
    {
        [JsonProperty(PropertyName ="Manager")]
        public string ManagerName { get; set; }
        public string YahooManagerId { get; set; }
        public string TeamName { get; set; }
        public List<MatchupPlayerDto> Players { get; set; }
        public float ActualScore => Players.Where(p => p.MatchupPosition != "BN").Sum(p => p.PointsScoredNonNull);
        public float ProjectedScore => Players.Where(p => p.MatchupPosition != "BN").Sum(p => p.ProjectedPointsNonNull);
    }

    public class MatchupPlayerDto : PlayerDto
    {
        public string MatchupPosition { get; set; }
        public float PointsScoredNonNull { get { return PointsScored ?? 0; } set { PointsScored = value; } }
        public float ProjectedPointsNonNull { get { return ProjectedPoints ?? 0; } set { ProjectedPoints = value; } }
        public float? PointsScored { get; set; }
        public float? ProjectedPoints { get; set; }
        public List<StatDto> Stats { get; set; }
        public FantasyPosition FantasyPosition => Util.ParseFantasyPosition(MatchupPosition);
    }
    public class StatDto

    {
        public string StatText { get; set; }
        public float Points { get; set; }
    }
}
