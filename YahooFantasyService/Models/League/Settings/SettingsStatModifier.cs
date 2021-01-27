using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class SettingsStatModifier
    {
        [JsonConstructor]
        public SettingsStatModifier(JToken[] bonuses)
        {
            Bonuses = bonuses
                ?.Select(s =>
                    JsonConvert.DeserializeObject<SettingsStatBonus>(s.SelectToken("bonus").ToString()))
                .ToList();
        }

        [JsonProperty(PropertyName = "stat_id")]
        public int StatId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "bonuses")]
        public List<SettingsStatBonus> Bonuses { get; set; }
    }

    public class SettingsStatBonus
    {
        [JsonProperty(PropertyName = "target")]
        public int Target { get; set; }

        [JsonProperty(PropertyName = "points")]
        public double Points { get; set; }
    }
}
