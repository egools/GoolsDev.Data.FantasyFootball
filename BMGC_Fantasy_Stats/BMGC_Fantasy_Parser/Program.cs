using AngleSharp;
using AngleSharp.Dom;
using FantasyComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FantasyParser
{
    class Program
    {
        static void Main(string[] args)
        {

            
            var path = Directory.GetDirectories("../../../HtmlSource/");
            //for(int week = 1; week <= 16; week++)
            //{
            //    var files = Directory.GetFiles("../../../HtmlSource/2019/Week" + week);
            //    foreach(var file in files)
            //    {
            //        var doc = GetDocument(file).Result;

            //    }
            //}

            var document = GetDocument(@"../../../HtmlSource/2019/Week1/gools_snow.html").Result;
            var players = document.QuerySelectorAll("#matchups #statTable1 tbody tr:not(.Last), #bench-table #statTable2 tbody tr:not(.Last)");

            var week = document.QuerySelector("#matchup_selectlist_nav .flyout-title").InnerHtml;
            var managerNames = document.QuerySelectorAll("#matchup-header .user-id").Select(elm => elm.InnerHtml).ToList();
            var teamNames = document.QuerySelectorAll("#matchup-header a.F-link").Select(elm => elm.InnerHtml).ToList();
            var league = new FantasyLeagueYear("BMGC");
            var season = new FantasySeason(2019);
            league.Seasons.Add(season);

            var leftManager = new FantasyTeam(managerNames[0], teamNames[0]);
            var rightManager = new FantasyTeam(managerNames[1], teamNames[1]);

            var leftTeam = new MatchupRoster(week);
            var rightTeam = new MatchupRoster(week);


            foreach (var row in players)
            {
                var pointsScoreElements = row.QuerySelectorAll(".Fw-b a.pps");
                var statNodeIDs = pointsScoreElements.Select(elm => elm.Attributes["data-stat-note-id"].Value).ToList();
                var fullNameLeft = document.QuerySelector($"#{statNodeIDs[0]} h2").InnerHtml.Replace(" Stat Breakdown", "");
                var fullNameRight = document.QuerySelector($"#{statNodeIDs[1]} h2").InnerHtml.Replace(" Stat Breakdown", "");
                var fantasyPosition = row.QuerySelector("td:nth-child(6) div").InnerHtml;
                var pointsScored = pointsScoreElements.Select(elm => elm.InnerHtml).ToList();
                var projectedLeft = row.QuerySelector("td:nth-child(3) div").InnerHtml;
                var projectedRight = row.QuerySelector("td:nth-child(9) div").InnerHtml;
                var shortNames = row.QuerySelectorAll(".player .ysf-player-name a").Select(elm => elm.InnerHtml).ToList();
                var team_pos = row.QuerySelectorAll(".player .ysf-player-name span").Select(elm => elm.InnerHtml.Replace(" ", "").Split('-')).ToList();
                var gameResults = row.QuerySelectorAll(".player .ysf-game-status a").Select(elm => elm.InnerHtml).ToList();

                var leftMatchupPlayer = new MatchupPlayer()
                {
                    //PlayerID = statNodeIDs[0],
                    ActualPoints = float.Parse(pointsScored[0]),
                    ProjectedPoints = float.Parse(projectedLeft),
                    MatchupPosition = Util.ParseFantasyPosition(fantasyPosition),
                    Player = new NFLPlayer(statNodeIDs[0])
                    {
                        FullName = fullNameLeft,
                        ShortName = shortNames[0],
                        NFLTeam = team_pos[0][0],
                        NFLPosition = Util.ParseNFLPosition(team_pos[0][1]),
                    }
                };
                var rightMatchupPlayer = new MatchupPlayer()
                {
                    //PlayerID = statNodeIDs[1],
                    ActualPoints = float.Parse(pointsScored[1]),
                    ProjectedPoints = float.Parse(projectedRight),
                    MatchupPosition = Util.ParseFantasyPosition(fantasyPosition),
                    Player = new NFLPlayer(statNodeIDs[1])
                    {
                        FullName = fullNameLeft,
                        ShortName = shortNames[1],
                        NFLTeam = team_pos[1][0],
                        NFLPosition = Util.ParseNFLPosition(team_pos[1][1]),
                    }
                };

                leftTeam.AddPlayer(leftMatchupPlayer);
                rightTeam.AddPlayer(rightMatchupPlayer);
            }

        }

        public static async Task<IDocument> GetDocument(string path)
        {
            var context = BrowsingContext.New(Configuration.Default);
            var html = File.ReadAllText(path);
            return await context.OpenAsync(req => req.Content(html));
        }

        







        
    }
}
