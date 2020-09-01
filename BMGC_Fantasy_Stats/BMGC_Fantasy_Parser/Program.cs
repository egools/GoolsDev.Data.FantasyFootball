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
            var year = 2019;
            //var games = PFRUtility.GetNFLRegularSeasonSchedule(year).ToList();
            //ParseSeasons();
            //var player = PFRUtility.FindPlayerInfo("Terrell Owens");
            _db.SaveChangesAsync().Wait();
        }

        public static Season GetSeasonByYahooId(int yid)
        {
            return _db.Seasons.FirstOrDefault(s => s.YahooLeagueId == yid);
        }

        public static void AddDataFromDraftDTO()
        {

        }

        public static void AddDataFromManagerDTO()
        {

        }

        public static void AddDataFromMatchupDTO()
        {

        }

        public static (string seasonName, int yahooSeasonId) SetNameAndYIdFromDTO(string name)
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

        public static void ParseSeasons()
        {
            var directories = Directory.GetDirectories("../../../app_data/");
            var drafts = new List<DraftDTO>();
            var managers = new List<ManagersDTO>();
            var matchups = new List<MatchupDTO>();
            foreach (var dir in directories)
            {
                var files = Directory.GetFiles(dir);
                var draftFile = files.FirstOrDefault(f => f.Contains("draft"));
                var managersFile = files.FirstOrDefault(f => f.Contains("managers"));
                if (draftFile != null)
                    drafts.Add(JsonConvert.DeserializeObject<DraftDTO>(File.ReadAllText(draftFile)));
                if (managersFile != null)
                    managers.Add(JsonConvert.DeserializeObject<ManagersDTO>(File.ReadAllText(managersFile)));

                var matchupFiles = Directory.GetFiles(Path.Combine(dir, "matchups"));
                foreach (var matchupFile in matchupFiles)
                {
                    matchups.Add(JsonConvert.DeserializeObject<MatchupDTO>(File.ReadAllText(matchupFile)));
                }
            }
            matchups = (from m in matchups
                        orderby int.Parse(m.SeasonYear) ascending, m.Week ascending
                        select m).ToList();
            var elos = new Dictionary<string, List<int>>();
            var elosMod = new Dictionary<string, List<int>>();
            foreach (var matchup in matchups)
            {
                if (!elos.ContainsKey(matchup.LeftTeam.Manager))
                {
                    elosMod.Add(matchup.LeftTeam.Manager, new List<int> { 1500 });
                    elos.Add(matchup.LeftTeam.Manager, new List<int> { 1500 });
                }
                if (!elos.ContainsKey(matchup.RightTeam.Manager))
                {
                    elos.Add(matchup.RightTeam.Manager, new List<int> { 1500 });
                    elosMod.Add(matchup.RightTeam.Manager, new List<int> { 1500 });
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
