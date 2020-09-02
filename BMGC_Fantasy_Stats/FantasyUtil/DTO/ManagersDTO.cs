using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FantasyComponents.DTO
{
    public class ManagersDTO : BaseDTO
    {
        public List<ManagerDTO> Managers { get; set; }
    }
    public class ManagerDTO
    {
        public string TeamName { get; set; }
        [JsonProperty(PropertyName ="Manager")]
        public string ManagerName { get; set; }
        public short MovesMade { get; set; }
        public short TradesMade { get; set; }
        public string YahooManagerId { get; set; }
    }
}
