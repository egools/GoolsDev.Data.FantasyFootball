using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyComponents.DTO
{
    public class ManagersDTO
    {
        public string LeagueName { get; set; }
        public string SeasonYear { get; set; }
        public List<ManagerDTO> Managers { get; set; }
    }
    public class ManagerDTO
    {
        public string TeamName { get; set; }
        public string Manager { get; set; }
        public int MovesMade { get; set; }
        public int TradesMade { get; set; }
    }
}
