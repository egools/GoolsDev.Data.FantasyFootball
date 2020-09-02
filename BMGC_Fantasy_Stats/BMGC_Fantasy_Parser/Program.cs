using AngleSharp;
using AngleSharp.Dom;
using FantasyComponents;
using FantasyComponents.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FantasyParser
{
    class Program
    {
        private static readonly FantasyFootballContextLocal _db = new FantasyFootballContextLocal();
        public static void Main(string[] args)
        {
            //var year = 2019;
            //var games = PFRUtility.GetNFLRegularSeasonSchedule(year).ToList();
            ParseSeasons();
            //var player = PFRUtility.FindPlayerInfo("Terrell Owens");
            //_db.SaveChangesAsync().Wait();
        }

        public static void AddDataFromManagerDTO(ManagersDTO managersDTO)
        {
            var (seasonName, yid) = GetNameAndYIdFromDTO(managersDTO.LeagueName);
            Season season = _db.Seasons
                .Include(s => s.ManagerSeasons)
                .FirstOrDefault(s => s.YahooLeagueId == yid);

            if (season is null)
            {
                season = new Season(short.Parse(managersDTO.SeasonYear), yid, seasonName);
                _db.Leagues
                    .Include(l => l.Seasons)
                    .First()
                    .Seasons
                    .Add(season);
            }

            foreach (ManagerDTO managerDTO in managersDTO.Managers)
            {
                Manager manager = _db.Managers
                    .Include(m => m.ManagerSeasons)
                    .FirstOrDefault(m => m.YahooManagerId == managerDTO.YahooManagerId);

                if (manager is null)
                {
                    manager = new Manager(managerDTO.YahooManagerId, managerDTO.ManagerName);
                    _db.Managers.Add(manager);
                }

                var managerSeason = season.ManagerSeasons.FirstOrDefault(ms => ms.ManagerId == manager.ManagerId);
                if (managerSeason is null)
                {
                    managerSeason = new ManagerSeason(managerDTO.TeamName)
                    {
                        MovesMade = managerDTO.MovesMade,
                        TradesMade = managerDTO.TradesMade,
                    };
                    manager.ManagerSeasons.Add(managerSeason);
                    season.ManagerSeasons.Add(managerSeason);
                }
                else
                {
                    managerSeason.MovesMade = managerDTO.MovesMade;
                    managerSeason.TradesMade = managerDTO.TradesMade;
                }
            }
            _db.SaveChangesAsync().Wait();
        }
        public static void AddDataFromDraftDTO(DraftDTO draftDTO)
        {
            var (seasonName, yid) = GetNameAndYIdFromDTO(draftDTO.LeagueName);
            Season season = _db.Seasons.FirstOrDefault(s => s.YahooLeagueId == yid)
                ?? new Season(short.Parse(draftDTO.SeasonYear), yid, seasonName);
        }
        public static void AddDataFromMatchupDTO(MatchupDTO matchupDTO)
        {
            var (seasonName, yid) = GetNameAndYIdFromDTO(matchupDTO.LeagueName);
            Season season = _db.Seasons
                .Include(s => s.ManagerSeasons)
                    .ThenInclude(ms => ms.Rosters)
                .Include(s => s.Matchups)
                .FirstOrDefault(s => s.YahooLeagueId == yid);
            ManagerSeason managerSeasonLeft = season.ManagerSeasons.FirstOrDefault(ms => ms.TeamName == matchupDTO.LeftTeam.TeamName);
            ManagerSeason managerSeasonRight = season.ManagerSeasons.FirstOrDefault(ms => ms.TeamName == matchupDTO.RightTeam.TeamName);

            var matchup = new Matchup(byte.Parse(matchupDTO.Week));
            AddPlayersFromTeamDTO(matchupDTO.LeftTeam, matchup.Roster1);
            AddPlayersFromTeamDTO(matchupDTO.RightTeam, matchup.Roster2);
            managerSeasonLeft.Rosters.Add(matchup.Roster1);
            managerSeasonRight.Rosters.Add(matchup.Roster2);
            season.Matchups.Add(matchup);
            _db.SaveChangesAsync().Wait();
        }

        public static (string seasonName, int yahooSeasonId) GetNameAndYIdFromDTO(string name)
        {
            try
            {
                var match = Regex.Match(name, "(.*) \\(ID# (\\d+)\\)");
                var seasonName = match.Groups["1"].Value;
                var yahooSeasonId = int.Parse(match.Groups["2"].Value);
                return (seasonName, yahooSeasonId);
            }
            catch
            {
                throw new ArgumentException("Name not formatted correctly (missing ID#)");
            }
        }

        public static void AddPlayersFromTeamDTO(TeamDTO team, MatchupRoster roster)
        {
            roster.ActualScore = team.ActualScore;
            roster.ProjectedScore = team.ProjectedScore;
            foreach (var playerDTO in team.Players)
            {
                var nflPlayer = _db.NFLPlayers.FirstOrDefault(p => p.YahooId == playerDTO.PlayerId);
                if (nflPlayer is null)
                {
                    nflPlayer = new NFLPlayer(playerDTO.PlayerId, playerDTO.FullName, playerDTO.ShortName);
                    _db.NFLPlayers.Add(nflPlayer);
                }
                if (string.IsNullOrEmpty(nflPlayer.ShortName))
                    nflPlayer.ShortName = playerDTO.ShortName;
                var matchupPosition = Util.ParseFantasyPosition(playerDTO.MatchupPosition);
                var player = new MatchupPlayer(nflPlayer, playerDTO.ProjectedPoints, playerDTO.PointsScored, matchupPosition);
                roster.MatchupPlayers.Add(player);
            }
        }

        public static void ParseSeasons()
        {
            var directories = Directory.GetDirectories("../../../app_data/");
            foreach (var dir in directories)
            {
                var files = Directory.GetFiles(dir);
                //var draftFile = files.FirstOrDefault(f => f.Contains("draft"));
                //var managersFile = files.FirstOrDefault(f => f.Contains("managers"));
                //if (draftFile != null)
                //    AddDataFromDraftDTO(JsonConvert.DeserializeObject<DraftDTO>(File.ReadAllText(draftFile)));
                //if (managersFile != null)
                //    AddDataFromManagerDTO(JsonConvert.DeserializeObject<ManagersDTO>(File.ReadAllText(managersFile)));

                var matchupFiles = Directory.GetFiles(Path.Combine(dir, "matchups"));
                foreach (var matchupFile in matchupFiles)
                {
                    AddDataFromMatchupDTO(JsonConvert.DeserializeObject<MatchupDTO>(File.ReadAllText(matchupFile)));
                }

            }
        }

        public (double, double) CalculateExpectedResult(int leftRating, int rightRating)
        {
            var leftExpected = 1 / (1 + Math.Pow(10, ((rightRating - leftRating) / 400)));
            var rightExpected = 1 - leftExpected;
            return (leftExpected, rightExpected);
        }

        public (int, int) CalculateEloChange(double leftExpected, double rightExpected, double leftScore, double rightScore)
        {
            var lWin = leftScore > rightScore;
            var rWin = !lWin;

            var leftChange = Convert.ToInt32(32 * ((lWin ? 1 : 0) - leftExpected));

            var rightChange = Convert.ToInt32(32 * ((rWin ? 1 : 0) - rightExpected));

            return (leftChange, rightChange);
        }

        public (int, int) CalculateEloChangeAdjusted(double leftExpected, double rightExpected, double leftScore, double rightScore, double leftProjected, double rightProjected)
        {
            var lWin = leftScore > rightScore;
            var rWin = !lWin;

            var leftMarginMod = Math.Tanh((leftScore - rightScore - 10) / 30) * 5;
            var leftProjectedMod = Math.Tanh((leftScore - leftProjected) / 30) * 5;
            var leftChange = Convert.ToInt32((32 + leftMarginMod) * ((lWin ? 1 : 0) - leftExpected) + leftProjectedMod);

            var rightMarginMod = Math.Tanh((rightScore - leftScore) / 30) * 5;
            var rightProjectedMod = Math.Tanh((rightScore - rightProjected) / 30) * 5;
            var rightChange = Convert.ToInt32((32 + rightMarginMod) * ((rWin ? 1 : 0) - rightExpected) + rightProjectedMod);

            return (leftChange, rightChange);
        }
    }
}
