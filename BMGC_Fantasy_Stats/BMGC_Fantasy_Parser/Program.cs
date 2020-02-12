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

            //#matchup-header .user-id => manager names
            //#matchup-header a.F-link => team names
            var week = document.QuerySelector("#matchup_selectlist_nav .flyout-title").InnerHtml;
            var managerNames = document.QuerySelectorAll("#matchup-header .user-id").Select(elm => elm.InnerHtml).ToList();
            var teamNames = document.QuerySelectorAll("#matchup-header a.F-link").Select(elm => elm.InnerHtml).ToList();

            var leftManager = new FantasyOwner(managerNames[0], teamNames[0]);
            var rightManager = new FantasyOwner(managerNames[1], teamNames[1]);

            var leftTeam = new FantasyTeam(week);
            var rightTeam = new FantasyTeam(week);

            //data-stat-note-id on clickable stat columns (.has-stat-note) includes ID for stat breakdown with player name ("#pps-31896")
            //e.g. document.querySelector("#pps-31896 h2").innerText => "DK Metcalf Stat Breakdown"

            //td:nth-child(6) div => row player position
            //.player .ysf-player-name a    => short name
            //.player .ysf-player-name span => team - pos
            //.player .ysf-game-status a[0] => game score / result
            //.player .ysf-game-status a[1] => opponent
            //.Fw-b a.pps                   => points scored
            //td[3/9] div                   => projected points


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
                    ActualPoints = float.Parse(pointsScored[0]),
                    ProjectedPoints = float.Parse(projectedLeft),
                    MatchupPosition = Util.ParseFantasyPosition(fantasyPosition),
                    Player = new NFLPlayer
                    {
                        FullName = fullNameLeft,
                        ShortName = shortNames[0],
                        NFLTeam = team_pos[0][0],
                        NFLPosition = Util.ParseNFLPosition(team_pos[0][1]),
                    }
                };
                var rightMatchupPlayer = new MatchupPlayer()
                {

                    ActualPoints = float.Parse(pointsScored[1]),
                    ProjectedPoints = float.Parse(projectedRight),
                    MatchupPosition = Util.ParseFantasyPosition(fantasyPosition),
                    Player = new NFLPlayer
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
            var t = leftTeam.IdealTeam();

        }

        public static async Task<IDocument> GetDocument(string path)
        {
            var context = BrowsingContext.New(Configuration.Default);
            var html = File.ReadAllText(path);
            return await context.OpenAsync(req => req.Content(html));
        }

        







        
    }
}
