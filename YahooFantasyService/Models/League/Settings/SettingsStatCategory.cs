using Newtonsoft.Json;
using System.Collections.Generic;

namespace YahooFantasyService
{
    public class SettingsStatCategory
    {
        [JsonProperty(PropertyName = "stat_id")]
        public int StatId { get; set; }

        [JsonProperty(PropertyName = "enabled")]
        public string Enabled { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "sort_order")]
        public string SortOrder { get; set; }

        [JsonProperty(PropertyName = "position_type")]
        public string PositionType { get; set; }

        [JsonProperty(PropertyName = "is_only_display_stat")]
        public string IsOnlyDisplayStat { get; set; }

        [JsonProperty(PropertyName = "is_excluded_from_display")]
        public string IsExcludedFromDisplay { get; set; }

        public List<SettingsStatPositionType> StatPositionTypes { get; set; }
    }

    public class SettingsStatPositionType
    {
        [JsonProperty(PropertyName = "position_type")]
        public string PositionType { get; set; }

        [JsonProperty(PropertyName = "is_only_display_stat")]
        public string IsOnlyDisplayStat { get; set; }
    }
}
