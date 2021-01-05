using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace FantasyComponents
{
    [Flags]
    public enum DraftType
    {
        Snake = 1,
        Auction = 2
    }

    [Flags]
    public enum NFLPosition
    {
        QB = 1,
        RB = 2,
        WR = 4,
        TE = 8,
        DEF = 16,
        K = 32,
        D = 64,
        Unknown = 128
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
        D = NFLPosition.D,
        K = NFLPosition.K,
        W_R_T = NFLPosition.RB | NFLPosition.WR | NFLPosition.TE,
        W_T = NFLPosition.WR | NFLPosition.TE,
        W_R = NFLPosition.WR | NFLPosition.RB,
        BN = NFLPosition.QB | NFLPosition.RB | NFLPosition.WR | NFLPosition.TE | NFLPosition.DEF | NFLPosition.K | NFLPosition.D
    }
    public static class Util
    {
        public static NFLPosition ParseNFLPosition(string pos)
        {
            if (pos == "QB") return NFLPosition.QB;
            else if (pos == "RB") return NFLPosition.RB;
            else if (pos == "WR") return NFLPosition.WR;
            else if (pos == "TE") return NFLPosition.TE;
            else if (pos == "DEF") return NFLPosition.DEF;
            else if (pos == "K") return NFLPosition.K;
            else if (pos == "D") return NFLPosition.D;
            else return NFLPosition.Unknown;
        }

        public static FantasyPosition ParseFantasyPosition(string pos)
        {
            if (pos == "QB") return FantasyPosition.QB;
            else if (pos == "RB") return FantasyPosition.RB1;
            else if (pos == "WR") return FantasyPosition.WR1;
            else if (pos == "TE") return FantasyPosition.TE;
            else if (pos == "W/R/T") return FantasyPosition.W_R_T;
            else if (pos == "W/R") return FantasyPosition.W_R;
            else if (pos == "W/T") return FantasyPosition.W_T;
            else if (pos == "DEF") return FantasyPosition.DEF;
            else if (pos == "D") return FantasyPosition.D;
            else if (pos == "K") return FantasyPosition.K;
            else if (pos == "BN") return FantasyPosition.BN;
            else return FantasyPosition.BN;
        }
    }
}
