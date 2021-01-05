using FantasyComponents;

namespace FantasyParser.DTO
{
    public class PlayerDto
    {
        public int? YahooPlayerId { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string PlayerPosition { get; set; }
        public string PlayerYahooTeamAbbr { get; set; }
        public NFLPosition NFLPosition => Util.ParseNFLPosition(PlayerPosition);
    }
}
