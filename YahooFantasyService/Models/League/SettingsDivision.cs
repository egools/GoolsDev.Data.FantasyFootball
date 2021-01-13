using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class SettingsDivision
    {
        [JsonPropertyName("division_id")]
        public int DivisionId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
