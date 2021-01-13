using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class LeagueSettings
    {
        [JsonPropertyName("draft_type")]
        public string DraftType { get; set; }

        [JsonPropertyName("is_auction_draft")]
        public string IsAuctionDraft { get; set; }

        [JsonPropertyName("scoring_type")]
        public string ScoringType { get; set; }

        [JsonPropertyName("persistent_url")]
        public string PersistentUrl { get; set; }

        [JsonPropertyName("uses_playoff")]
        public string UsesPlayoff { get; set; }

        [JsonPropertyName("has_playoff_consolation_games")]
        public bool HasPlayoffConsolationGames { get; set; }

        [JsonPropertyName("playoff_start_week")]
        public string PlayoffStartWeek { get; set; }

        [JsonPropertyName("uses_playoff_reseeding")]
        public int UsesPlayoffReseeding { get; set; }

        [JsonPropertyName("uses_lock_eliminated_teams")]
        public int UsesLockEliminatedTeams { get; set; }

        [JsonPropertyName("num_playoff_teams")]
        public string NumPlayoffTeams { get; set; }

        [JsonPropertyName("num_playoff_consolation_teams")]
        public int NumPlayoffConsolationTeams { get; set; }

        [JsonPropertyName("has_multiweek_championship")]
        public int HasMultiweekChampionship { get; set; }

        [JsonPropertyName("waiver_type")]
        public string WaiverType { get; set; }

        [JsonPropertyName("waiver_rule")]
        public string WaiverRule { get; set; }

        [JsonPropertyName("uses_faab")]
        public string UsesFaab { get; set; }

        [JsonPropertyName("draft_time")]
        public string DraftTime { get; set; }

        [JsonPropertyName("draft_pick_time")]
        public string DraftPickTime { get; set; }

        [JsonPropertyName("post_draft_players")]
        public string PostDraftPlayers { get; set; }

        [JsonPropertyName("max_teams")]
        public string MaxTeams { get; set; }

        [JsonPropertyName("waiver_time")]
        public string WaiverTime { get; set; }

        [JsonPropertyName("trade_end_date")]
        public string TradeEndDate { get; set; }

        [JsonPropertyName("trade_ratify_type")]
        public string TradeRatifyType { get; set; }

        [JsonPropertyName("trade_reject_time")]
        public string TradeRejectTime { get; set; }

        [JsonPropertyName("player_pool")]
        public string PlayerPool { get; set; }

        [JsonPropertyName("cant_cut_list")]
        public string CantCutList { get; set; }

        [JsonPropertyName("sendbird_channel_url")]
        public string SendbirdChannelUrl { get; set; }

        [JsonPropertyName("pickem_enabled")]
        public string PickemEnabled { get; set; }

        [JsonPropertyName("uses_fractional_points")]
        public string UsesFractionalPoints { get; set; }

        [JsonPropertyName("uses_negative_points")]
        public string UsesNegativePoints { get; set; }


        public List<SettingsRosterPosition> RosterPositions { get; set; }
        public List<SettingsStatCategory> StatCategories { get; set; }
        public List<SettingsStatModifier> StatModifiers { get; set; }
        public List<SettingsDivision> Divisions { get; set; }
    }
}
