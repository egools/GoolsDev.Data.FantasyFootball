namespace FantasyFootball.Common.Enums
{
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
}