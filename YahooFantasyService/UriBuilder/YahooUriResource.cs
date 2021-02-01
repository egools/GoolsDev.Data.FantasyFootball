using System;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooUriResource : YahooUriPart
    {
        public YahooUriResource(string resource, List<YahooFilter> filters)
        {
            Resource = resource;
            Filters = filters;
        }

        public YahooUriResource(string resource, string key, Enum subresources)
        {
            Resource = resource;
            ResourceKey = key;
            Subresources = subresources;
            Filters = new List<YahooFilter>();
        }


        public string Resource { get; set; }
        public string ResourceKey { get; set; }
        public List<YahooFilter> Filters { get; set; }
        public Enum Subresources { get; set; }

        public override string ToString()
        {
            var key = !string.IsNullOrWhiteSpace(ResourceKey)
                ? "/" + ResourceKey
                : string.Empty;
            var filter = Filters.Any()
                ? ";" + string.Join(";", Filters)
                : string.Empty;
            var subresource = Convert.ToInt32(Subresources) != 0
                ? ";out=" + Subresources.ToString()
                : string.Empty;

            return $"/{Resource}{key}{filter}{subresource}";
        }
    }

}
