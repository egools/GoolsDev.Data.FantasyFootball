using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyComponents
{
    public static class Util
    {
        public enum NFLPosition
        {
            QB = 1,
            RB = 2,
            WR = 3,
            TE = 4,
            DEF = 5,
            K = 6,
            Unknown = 99
        }

        public enum FantasyPosition
        {
            QB = 10,
            RB1 = 20,
            RB2 = 21,
            WR1 = 30,
            WR2 = 31,
            TE = 40,
            DEF = 50,
            K = 60,
            FLEX = 99,
            BN = 100
        }

        public static NFLPosition ParseNFLPosition(string pos)
        {
            if (pos == "QB") return NFLPosition.QB;
            else if (pos == "RB") return NFLPosition.RB;
            else if (pos == "WR") return NFLPosition.WR;
            else if (pos == "TE") return NFLPosition.TE;
            else if (pos == "DEF") return NFLPosition.DEF;
            else if (pos == "K") return NFLPosition.K;
            else return NFLPosition.Unknown;
        }

        public static FantasyPosition ParseFantasyPosition(string pos)
        {
            if (pos == "QB") return FantasyPosition.QB;
            else if (pos == "RB") return FantasyPosition.RB1;
            else if (pos == "WR") return FantasyPosition.WR1;
            else if (pos == "TE") return FantasyPosition.TE;
            else if (pos == "W/R/T") return FantasyPosition.FLEX;
            else if (pos == "DEF") return FantasyPosition.DEF;
            else if (pos == "K") return FantasyPosition.K;
            else if (pos == "BN") return FantasyPosition.BN;
            else return FantasyPosition.BN;
        }

        public static readonly List<FantasyPosition> ValidRoster = new List<FantasyPosition>
        {
            FantasyPosition.QB,
            FantasyPosition.RB1,
            FantasyPosition.RB2,
            FantasyPosition.WR1,
            FantasyPosition.WR2,
            FantasyPosition.TE ,
            FantasyPosition.DEF,
            FantasyPosition.K,
            FantasyPosition.FLEX,
        };
    }
}
