using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyComponents
{
    public class FantasyLeague
    {
        public string Name { get; set; }
        public Dictionary<string, FantasyOwner> Owners { get; }
        public List<FantasySeason> Seasons { get; }

        public FantasyLeague(string name)
        {
            Name = name;
            Owners = new Dictionary<string, FantasyOwner>();
            Seasons = new List<FantasySeason>();
        }
    }
}
