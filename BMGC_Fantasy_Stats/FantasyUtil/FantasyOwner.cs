using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyComponents
{
    public class FantasyOwner
    {
        public string ManagerName { get; set; }
        public string TeamName { get; set; }
        public List<FantasyTeam> Weeks { get; set; }

        public FantasyOwner(string managerName, string teamName)
        {
            ManagerName = managerName;
            TeamName = teamName;
            Weeks = new List<FantasyTeam>();
        }
    }
}
