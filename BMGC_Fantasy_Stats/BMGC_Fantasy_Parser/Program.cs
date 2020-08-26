using AngleSharp;
using AngleSharp.Dom;
using FantasyComponents;
using FantasyComponents.DTO;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace FantasyParser
{
    class Program
    {
        static void Main(string[] args)
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

            //var document = GetDocument("https://sports.yahoo.com/nfl/players/{ysPlayerId}/").Result;
            //var a = document.QuerySelector(".ys-name").Text();
            var managerMatchups = new Dictionary<string, List<TeamDTO>>();
            foreach (var matchup in matchups)
            {
                if (managerMatchups.ContainsKey(matchup.LeftTeam.Manager))
                    managerMatchups[matchup.LeftTeam.Manager].Add(matchup.LeftTeam);
                else
                    managerMatchups.Add(matchup.LeftTeam.Manager, new List<TeamDTO> { matchup.LeftTeam });

                if (managerMatchups.ContainsKey(matchup.RightTeam.Manager))
                    managerMatchups[matchup.RightTeam.Manager].Add(matchup.RightTeam);
                else
                    managerMatchups.Add(matchup.RightTeam.Manager, new List<TeamDTO> { matchup.RightTeam });
            }
        }

        public static async Task<IDocument> GetDocument(string url)
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            return await context.OpenAsync(url);
        }
    }
}
