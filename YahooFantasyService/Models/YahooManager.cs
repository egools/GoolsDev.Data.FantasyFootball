using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class YahooManager
    {
        [JsonPropertyName("manager_id")]
        public string ManagerId { get; set; }

        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName("guid")]
        public string Guid { get; set; }
    }




}
