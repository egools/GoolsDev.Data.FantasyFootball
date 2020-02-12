using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyComponents
{
    public class FantasyMatchup
    {
        public FantasyTeam LeftTeam { get; set; }
        public FantasyTeam RightTeam { get; set; }

        public int Winner => LeftTeam.CompareTo(RightTeam);
    }
}
