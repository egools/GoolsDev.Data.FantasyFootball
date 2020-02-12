using System;
using System.Collections.Generic;

namespace FantasyComponents
{
    public class FantasySeason
    {
        public int Year { get; set; }
        public List<FantasyOwner> Owners { get; set; }
        public List<FantasyMatchup> Matchups { get; set; }
    }
}
