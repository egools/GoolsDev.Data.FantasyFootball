using System;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooUriCollection : YahooUriPart
    {
        public string Collection { get; set; }
        public string Resource { get; set; }

        public List<string> ResourceKeys { get; set; }
        public List<YahooFilter> Filters { get; set; }
        public Enum Subresources { get; set; }

        public override string ToString()
        {
            var filter = Filters.Any()
                ? ";" + string.Join(";", Filters)
                : string.Empty;
            var subresource = Convert.ToInt32(Subresources) != 0
                ? ";out=" + Subresources.ToString()
                : string.Empty;

            return $"/{Collection}/{Resource}_keys={string.Join(",", ResourceKeys)}{filter}{subresource}";
        }
    }

    public class LeagueCollectionUri : YahooUriCollection
    {
        public new string Collection = "leagues";
        public new string Resource = "league";
    }
    public class TeamCollectionUri : YahooUriCollection
    {
        public new string Collection = "teams";
        public new string Resource = "team";
    }

    public class PlayerCollectionUri : YahooUriCollection
    {
        public new string Collection = "players";
        public new string Resource = "player";
    }

}
