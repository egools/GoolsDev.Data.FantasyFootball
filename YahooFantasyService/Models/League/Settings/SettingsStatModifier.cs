using Newtonsoft.Json;
using System.Collections.Generic;

namespace YahooFantasyService
{
    public class SettingsStatModifier
    {
        [JsonProperty(PropertyName = "stat_id")]
        public int StatId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        public List<SettingsStatBonus> Bonuses { get; set; }
    }

    public class SettingsStatBonus
    {
        public int Target { get; set; }
        public double Points { get; set; }
    }
}
