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
        Unknown = 0,
        O = 1,
        K = 2,
        DT = 4,
        DP = 8,
        IR = 16
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
            return pos switch
            {
                "QB" => NFLPosition.QB,
                "RB" => NFLPosition.RB,
                "WR" => NFLPosition.WR,
                "TE" => NFLPosition.TE,
                "DEF" => NFLPosition.DEF,
                "K" => NFLPosition.K,
                "D" => NFLPosition.D,
                _ => NFLPosition.None
            };
        }

        public static FantasyPosition ParseFantasyPosition(string pos)
        {
            return pos switch
            {
                "BN" => FantasyPosition.BN,
                "QB" => FantasyPosition.QB,
                "WR" => FantasyPosition.WR,
                "RB" => FantasyPosition.RB,
                "TE" => FantasyPosition.TE,
                "K" => FantasyPosition.K,
                "DEF" => FantasyPosition.DEF,
                "W/R/T" => FantasyPosition.W_R_T,
                "W/R" => FantasyPosition.W_R,
                "W/T" => FantasyPosition.W_T,
                "D" => FantasyPosition.D,
                "IR" => FantasyPosition.IR,
                _ => FantasyPosition.BN
            };
        }

        public static PositionType ParsePositionType(string posType)
        {
            return posType switch
            {
                "O" => PositionType.O,
                "K" => PositionType.K,
                "DT" => PositionType.DT,
                "DP" => PositionType.DP,
                "IR" => PositionType.IR,
                _ => PositionType.Unknown
            };
        }
    }
}