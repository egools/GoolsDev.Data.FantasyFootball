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
    public enum PositionType
    {
        O = 1,
        K = 2,
        DT = 4,
        DP = 8
    }

    [Flags]
    public enum NFLPosition
    {
        None = 0,
        QB = 1,
        RB = 2,
        WR = 4,
        TE = 8,
        DEF = 16,
        K = 32,
        D = 64
    }

    [Flags]
    public enum FantasyPosition
    {
        BN = 0,
        QB = 1,
        WR = 2,
        RB = 4,
        TE = 8,
        K = 16,
        DEF = 32,
        W_R_T = 64,
        W_R = 128,
        W_T = 256,
        D = 512,
        IR = 1024
    }

    public static class PositionUtilities
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
            else return NFLPosition.None;
        }

        public static FantasyPosition ParseFantasyPosition(string pos)
        {
            if (pos == "BN") return FantasyPosition.BN;
            if (pos == "QB") return FantasyPosition.QB;
            if (pos == "WR") return FantasyPosition.WR;
            if (pos == "RB") return FantasyPosition.RB;
            if (pos == "TE") return FantasyPosition.TE;
            if (pos == "K") return FantasyPosition.K;
            if (pos == "DEF") return FantasyPosition.DEF;
            if (pos == "W/R/T") return FantasyPosition.W_R_T;
            if (pos == "W/R") return FantasyPosition.W_R;
            if (pos == "W/T") return FantasyPosition.W_T;
            if (pos == "D") return FantasyPosition.D;
            if (pos == "IR") return FantasyPosition.IR;
            else return FantasyPosition.BN;
        }
    }
}
