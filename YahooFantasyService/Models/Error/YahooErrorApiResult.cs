using Newtonsoft.Json;
using System.Net;

namespace YahooFantasyService
{
    public class YahooErrorApiResult : YahooApiResultBase
    {
        [JsonProperty(PropertyName = "error")]
        public YahooError Error { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
