using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyComponents
{
    public static class Util
    {
        [Flags]
        public enum NFLPosition
        {
            QB = 1,
            RB = 2,
            WR = 4,
            TE = 8,
            DEF = 16,
            K = 32,
            Unknown = 64
        }

        [Flags]
        public enum FantasyPosition
        {
            QB = NFLPosition.QB,
            RB1 = NFLPosition.RB,
            RB2 = NFLPosition.RB,
            WR1 = NFLPosition.WR,
            WR2 = NFLPosition.WR,
            TE = NFLPosition.TE,
            DEF = NFLPosition.DEF,
            K = NFLPosition.K,
            FLEX = NFLPosition.RB | NFLPosition.WR | NFLPosition.TE,
            BN = NFLPosition.QB | NFLPosition.RB | NFLPosition.WR | NFLPosition.TE | NFLPosition.DEF | NFLPosition.K
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
