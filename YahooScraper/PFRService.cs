using AngleSharp.Dom;
using FantasyDAO.YahooHtmlScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace YahooScraper
{
    public static class PFRService
    {
        private struct ScheduleFields
        {
            public static readonly string WeekNum = "[data-stat='week_num']";
            public static readonly string GameDate = "[data-stat='game_date']";
            public static readonly string GameTime = "[data-stat='gametime']";
            public static readonly string Winner = "[data-stat='winner'] a";
            public static readonly string Loser = "[data-stat='loser'] a";
            public static readonly string Location = "[data-stat='game_location']";
            public static readonly string WinnerPoints = "[data-stat='pts_win']";
            public static readonly string LoserPoints = "[data-stat='pts_lose']";
        }

        private struct PlayerFields
        {
            public static readonly string Year = "[data-stat='year_id']";
            public static readonly string Team = "[data-stat='team'] a";
            public static readonly string Week = "[data-stat='week_num']";
        }

        private static Func<string, string> GetAbbr = (str) => Regex.Replace(str, "/teams/(.*)/\\d{4}\\.htm", "$1");
        public static async Task<IEnumerable<PFRGame>> GetNFLRegularSeasonSchedule(int year) => await GetNFLGames(year, $"#games th[data-stat='week_num']");
        public static async Task<IEnumerable<PFRGame>> GetRegularSeasonGames(int year, int week) => await GetNFLGames(year, $"#games th[data-stat='week_num'][csk='{week}']");
        private static async Task<IEnumerable<PFRGame>> GetNFLGames(int year, string selector)
        {
            var document = await AngleSharpHelper.GetDocumentFromUrl($"https://www.pro-football-reference.com/years/{year}/games.htm");
            var weekElements = document.QuerySelectorAll(selector);

            var games = new List<PFRGame>();
            foreach (var weekElement in weekElements)
            {
                if (int.TryParse(weekElement.Text(), out _))
                    games.Add(PFFGameFromRow(weekElement.ParentElement));
            }
            return games;
        }

        private static PFRGame PFFGameFromRow(IElement game)
        {
            if (game.TagName.ToLower() != "tr" || game.Children.Any(elm => !elm.HasAttribute("data-stat")))
                throw new ArgumentException("Invalid row element (does not represent game)");
            try
            {
                var week = game.GetText(ScheduleFields.WeekNum);
                var gameDate = game.QuerySelector(ScheduleFields.GameDate).GetAttribute("csk");
                var gameTime = game.GetText(ScheduleFields.GameTime);
                var gameDateTime = DateTime.Parse($"{gameDate} {gameTime}").ToUniversalTime();
                var winner = game.QuerySelector(ScheduleFields.Winner);
                var loser = game.QuerySelector(ScheduleFields.Loser);
                var winnerLong = winner.Text();
                var loserLong = loser.Text();
                var winnerAbbr = GetAbbr(winner.GetAttribute("href"));
                var loserAbbr = GetAbbr(loser.GetAttribute("href"));
                var location = game.GetText(ScheduleFields.Location);
                var ptsWin = game.GetText(ScheduleFields.WinnerPoints);
                var ptsLose = game.GetText(ScheduleFields.LoserPoints);
                return new PFRGame
                {
                    Week = int.Parse(week),
                    GameDateTime = gameDateTime,
                    Winner = new PFRScheduleTeam
                    {
                        LongName = winnerLong,
                        PFRAbbr = winnerAbbr,
                        Score = int.TryParse(ptsWin, out var scWin) ? scWin : 0
                    },
                    Loser = new PFRScheduleTeam
                    {
                        LongName = loserLong,
                        PFRAbbr = loserAbbr,
                        Score = int.TryParse(ptsLose, out var scLose) ? scLose : 0
                    },
                    Location = location == "@" ? loserAbbr : winnerAbbr
                };
            }
            catch
            {
                throw new ArgumentException("Invalid row element");
            }
        }

        public static async Task<PFRPlayer> FindPlayerInfo(string playerName)
        {
            var urlEncodedName = HttpUtility.UrlEncode(playerName);
            var playerDoc = await AngleSharpHelper.GetDocumentFromUrl($"https://www.pro-football-reference.com/search/search.fcgi?search={urlEncodedName}");
            if (!playerDoc.BaseUri.Contains("player"))
                throw new ArgumentException("Player name is not distinct.");
            var player = new PFRPlayer(playerDoc.BaseUri);
            var hasMutlipleTeams = playerDoc.QuerySelectorAll(PlayerFields.Team).Select(t => t.Text()).Distinct().Count() > 1;
            if (hasMutlipleTeams)
            {
                playerDoc = await AngleSharpHelper.GetDocumentFromUrl(player.BaseUri.Replace(".htm", "/gamelog/"));
                var games = playerDoc.QuerySelectorAll("#stats tr[id^=stats]");
                var currentYear = int.Parse(games.First().GetText(PlayerFields.Year));
                var currentTeam = GetAbbr(games.First().QuerySelector(PlayerFields.Team).GetAttribute("href"));
                var currentWeek = 1;
                player.AddTeamToGameLog(currentTeam, currentYear, 1);
                foreach (var game in games)
                {
                    var thisYear = int.Parse(game.GetText(PlayerFields.Year));
                    var thisTeam = GetAbbr(game.QuerySelector(PlayerFields.Team).GetAttribute("href"));
                    var thisWeek = int.Parse(game.GetText(PlayerFields.Week));
                    if (thisTeam != currentTeam)
                    {
                        player.GameLog[currentTeam].EndYear = currentYear;
                        player.GameLog[currentTeam].EndWeek = currentWeek;
                        player.AddTeamToGameLog(thisTeam, thisYear, thisWeek);
                    }
                    currentTeam = thisTeam;
                    currentYear = thisYear;
                    currentWeek = thisWeek;
                }
            }
            else
            {
                var startYear = int.Parse(playerDoc.QuerySelector(".stats_table tbody").GetText(PlayerFields.Year));
                var teamAbbr = GetAbbr(playerDoc.QuerySelector(".stats_table tbody").QuerySelector(PlayerFields.Team).GetAttribute("href"));
                player.AddTeamToGameLog(teamAbbr, startYear, 1);
            }

            return player;
        }

        public static void GetPlayerGameLog(string baseUri)
        {

        }
    }

    public class PFRScheduleTeam
    {
        public string LongName { get; set; }
        public string PFRAbbr { get; set; }
        public int Score { get; set; }
    }

    public class PFRGame
    {
        public int Week { get; set; }
        public DateTime GameDateTime { get; set; }
        public PFRScheduleTeam Winner { get; set; }
        public PFRScheduleTeam Loser { get; set; }
        public string Location { get; set; }
    }

    public class PFRPlayer
    {
        public string BaseUri;
        public Dictionary<string, PFRTeamTenure> GameLog { get; set; }

        public PFRPlayer(string baseUri)
        {
            BaseUri = baseUri;
            GameLog = new Dictionary<string, PFRTeamTenure>();
        }

        public void AddTeamToGameLog(string teamAbbr, int startYear, int startWeek)
        {
            GameLog.Add(teamAbbr, new PFRTeamTenure(teamAbbr, startYear, startWeek));
        }

        public string GetTeam(int year, int week)
        {
            return GameLog.Values.FirstOrDefault(tenure =>
                tenure.StartYear <= year &&
                tenure.EndYear >= year &&
                tenure.StartWeek <= week &&
                tenure.EndWeek >= week)?.PFRAbbr ?? "N/A";
        }

        public class PFRTeamTenure
        {
            public PFRTeamTenure(string pFRAbbr, int startYear, int startWeek)
            {
                PFRAbbr = pFRAbbr;
                StartYear = startYear;
                StartWeek = startWeek;
                EndYear = int.MaxValue;
                EndWeek = int.MaxValue;
            }

            public string PFRAbbr { get; set; }
            public int StartYear { get; set; }
            public int StartWeek { get; set; }
            public int EndYear { get; set; }
            public int EndWeek { get; set; }
        }
    }

}
