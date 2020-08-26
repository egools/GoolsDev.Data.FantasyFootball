using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyComponents.DTO
{
    public class DraftDTO
    {
        public string LeagueName { get; set; }
        public string SeasonYear { get; set; }
        public List<DraftTeamDTO> Teams { get; set; }
        public bool IsAuction { get; set; }
    }

    public class DraftTeamDTO
    {
        public string TeamName { get; set; }
        public List<DraftedPlayerDTO> Players { get; set; }
    }
    public class DraftedPlayerDTO
    {
        public int Round { get; set; }
        public int DraftPosition { get; set; }
        public string FullName { get; set; }
        public int? PlayerId { get; set; }
        public int? Price { get; set; }
    }



}
