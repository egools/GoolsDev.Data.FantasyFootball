using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasyService
{
    public static class YahooEnums
    {
        [Flags]
        public enum LeagueSubresource
        {
            None = 0,
            Settings = 1,
            DraftResults = 2,
            Standings = 4,
            Scoreboard = 8
        }


        [Flags]
        public enum TeamSubresource
        {
            None = 0
        }

        [Flags]
        public enum PlayerSubresource
        {
            None = 0,
            Stats = 1
        }

        public static readonly LeagueSubresource AllLeagueResources =
            LeagueSubresource.Settings |
            LeagueSubresource.DraftResults |
            LeagueSubresource.Standings |
            LeagueSubresource.Scoreboard;
    }
}
