using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class SettingsStatModifier
    {
        [JsonPropertyName("stat_id")]
        public int StatId { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        public List<SettingsStatBonus> Bonuses { get; set; }
    }

    public class SettingsStatBonus
    {
        public int Target { get; set; }
        public double Points { get; set; }
    }
}
