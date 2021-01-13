using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class YahooLeagueBase
    {
        [JsonPropertyName("league_key")]
        public string LeagueKey { get; set; }

        [JsonPropertyName("league_id")]
        public string LeagueId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("logo_url")]
        public string LogoUrl { get; set; }

        [JsonPropertyName("draft_status")]
        public string DraftStatus { get; set; }

        [JsonPropertyName("num_teams")]
        public int NumTeams { get; set; }

        [JsonPropertyName("edit_key")]
        public string EditKey { get; set; }

        [JsonPropertyName("weekly_deadline")]
        public string WeeklyDeadline { get; set; }

        [JsonPropertyName("league_update_timestamp")]
        public string LeagueUpdateTimestamp { get; set; }

        [JsonPropertyName("scoring_type")]
        public string ScoringType { get; set; }

        [JsonPropertyName("league_type")]
        public string LeagueType { get; set; }

        [JsonPropertyName("renew")]
        public string Renew { get; set; }

        [JsonPropertyName("renewed")]
        public string Renewed { get; set; }

        [JsonPropertyName("iris_group_chat_id")]
        public string IrisGroupChatId { get; set; }

        [JsonPropertyName("allow_add_to_dl_extra_pos")]
        public int AllowAddToDlExtraPos { get; set; }

        [JsonPropertyName("is_pro_league")]
        public string IsProLeague { get; set; }

        [JsonPropertyName("is_cash_league")]
        public string IsCashLeague { get; set; }

        [JsonPropertyName("current_week")]
        public string CurrentWeek { get; set; }

        [JsonPropertyName("start_week")]
        public string StartWeek { get; set; }

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }

        [JsonPropertyName("end_week")]
        public string EndWeek { get; set; }

        [JsonPropertyName("end_date")]
        public string EndDate { get; set; }

        [JsonPropertyName("is_finished")]
        public int IsFinished { get; set; }

        [JsonPropertyName("game_code")]
        public string GameCode { get; set; }

        [JsonPropertyName("season")]
        public string Season { get; set; }
    }
}
