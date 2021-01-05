using System.Collections.Generic;

namespace FantasyParser.DTO
{
    public class DraftDto : BaseDto
    {
        public List<DraftTeamDto> Teams { get; set; }
        public bool IsAuction { get; set; }
        public int Budget { get; set; }
    }

    public class DraftTeamDto
    {
        public string TeamName { get; set; }
        public List<DraftedPlayerDto> Players { get; set; }
    }
    public class DraftedPlayerDto : PlayerDto
    {
        public short Round { get; set; }
        public short DraftPosition { get; set; }
        public short Price { get; set; }
    }



}
