using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class YahooError
    {

        [JsonProperty(PropertyName = "yahoo:uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "detail")]
        public string Detail { get; set; }
    }
}
