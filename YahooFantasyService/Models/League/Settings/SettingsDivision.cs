using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class SettingsDivision
    {
        [JsonProperty(PropertyName = "division_id")]
        public int DivisionId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
