namespace FantasyFootball.Common.Enums
{
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
}