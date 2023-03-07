namespace FantasyFootball.Common.Enums
{
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