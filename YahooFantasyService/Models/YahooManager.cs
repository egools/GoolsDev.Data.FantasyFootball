using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class YahooManager
    {
        [JsonProperty(PropertyName = "manager_id")]
        public string ManagerId { get; set; }

        [JsonProperty(PropertyName = "nickname")]
        public string Nickname { get; set; }

        [JsonProperty(PropertyName = "guid")]
        public string Guid { get; set; }
    }




}
