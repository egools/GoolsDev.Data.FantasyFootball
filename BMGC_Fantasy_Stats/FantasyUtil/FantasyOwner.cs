using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyComponents
{
    public class FantasyOwner : IComparable
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

        public int CompareTo(object obj)
        {
            return ManagerName.CompareTo(obj);
        }
    }
}
