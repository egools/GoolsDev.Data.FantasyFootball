using Newtonsoft.Json;
using System.Collections.Generic;

namespace FantasyParser.DTO
{
    public class ManagersDto : BaseDto
    {
        public List<ManagerDto> Managers { get; set; }
    }
    public class ManagerDto
    {
        public string TeamName { get; set; }
        [JsonProperty(PropertyName ="Manager")]
        public string ManagerName { get; set; }
        public short MovesMade { get; set; }
        public short TradesMade { get; set; }
        public string YahooManagerId { get; set; }
    }
}
