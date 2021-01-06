using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class YahooLeagueSettings
    {

    }

    public class YahooApiResult
    {
        [JsonPropertyName("fantasy_content")]
        public FantasyContent FantasyContent { get; set; }
    }

    public class FantasyContent
    {
        [JsonPropertyName("xml:lang")]
        public string XmlLang { get; set; }

        [JsonPropertyName("yahoo:uri")]
        public string YahooUri { get; set; }

        [JsonPropertyName("league")]
        public List<League> League { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }

        [JsonPropertyName("refresh_rate")]
        public string RefreshRate { get; set; }
    }

    public class League
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

        [JsonPropertyName("settings")]
        public List<Setting> Settings { get; set; }
    }

    public class Setting
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

        [JsonPropertyName("roster_positions")]
        public List<RosterPositionWrapper> RosterPositions { get; set; }

        [JsonPropertyName("stat_categories")]
        public StatCategoriesWrapper StatCategories { get; set; }

        [JsonPropertyName("stat_modifiers")]
        public StatModifiersWrapper StatModifiers { get; set; }

        [JsonPropertyName("divisions")]
        public List<Division> Divisions { get; set; }

        [JsonPropertyName("pickem_enabled")]
        public string PickemEnabled { get; set; }

        [JsonPropertyName("uses_fractional_points")]
        public string UsesFractionalPoints { get; set; }

        [JsonPropertyName("uses_negative_points")]
        public string UsesNegativePoints { get; set; }
    }

    public class RosterPositionWrapper
    {
        [JsonPropertyName("roster_position")]
        public RosterPosition RosterPosition { get; set; }
    }

    public class StatCategoriesWrapper
    {
        [JsonPropertyName("stats")]
        public List<StatCategoryWrapper> Collection { get; set; }
    }

    public class StatModifiersWrapper
    {
        [JsonPropertyName("stats")]
        public List<StatModifierWrapper> Collection { get; set; }
    }

    public class StatModifierWrapper
    {
        [JsonPropertyName("stat")]
        public StatModifier StatModifier { get; set; }
    }

    public class StatCategoryWrapper
    {
        [JsonPropertyName("stat")]
        public StatCategory StatCategory { get; set; }
    }


    public class RosterPosition
    {
        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("position_type")]
        public string PositionType { get; set; }

        [JsonPropertyName("count")]
        public object Count { get; set; }
    }

    public class StatPositionType
    {
        [JsonPropertyName("position_type")]
        public string PositionType { get; set; }

        [JsonPropertyName("is_only_display_stat")]
        public string IsOnlyDisplayStat { get; set; }
    }

    public class StatPositionTypeWrapper
    {
        [JsonPropertyName("stat_position_type")]
        public StatPositionType Collection { get; set; }
    }

    public class StatCategory
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

        [JsonPropertyName("stat_position_types")]
        public List<StatPositionTypeWrapper> StatPositionTypes { get; set; }

        [JsonPropertyName("is_only_display_stat")]
        public string IsOnlyDisplayStat { get; set; }

        [JsonPropertyName("is_excluded_from_display")]
        public string IsExcludedFromDisplay { get; set; }
    }

    public class StatModifier
    {
        [JsonPropertyName("stat_id")]
        public int StatId { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Division
    {
        [JsonPropertyName("division_id")]
        public int DivisionId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class DivisionWrapper
    {
        [JsonPropertyName("division")]
        public Division Division { get; set; }
    }
}
