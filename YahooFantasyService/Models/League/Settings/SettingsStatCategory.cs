using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class SettingsStatCategory
    {
        [JsonPropertyName("stat_id")]
        public int StatId { get; set; }

        [JsonPropertyName("enabled")]
        public string Enabled { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("sort_order")]
        public string SortOrder { get; set; }

        [JsonPropertyName("position_type")]
        public string PositionType { get; set; }

        [JsonPropertyName("is_only_display_stat")]
        public string IsOnlyDisplayStat { get; set; }

        [JsonPropertyName("is_excluded_from_display")]
        public string IsExcludedFromDisplay { get; set; }

        public List<SettingsStatPositionType> StatPositionTypes { get; set; }
    }

    public class SettingsStatPositionType
    {
        [JsonPropertyName("position_type")]
        public string PositionType { get; set; }

        [JsonPropertyName("is_only_display_stat")]
        public string IsOnlyDisplayStat { get; set; }
    }
}
