using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BMGC_Fantasy_Parser
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


            var document = GetDocument(@"C:\Users\egoolsby\Documents\0_MyFiles\BMGC\BMGC_Fantasy_Stats\BMGC_Fantasy_Parser\HtmlSource\2019\Week1\gools_snow.html").Result;
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
                    MatchupPosition = ParseFantasyPosition(fantasyPosition),
                    Player = new NFLPlayer
                    {
                        FullName = fullNameLeft,
                        ShortName = shortNames[0],
                        NFLTeam = team_pos[0][0],
                        NFLPosition = ParseNFLPosition(team_pos[0][1]),
                    }
                };
                var rightMatchupPlayer = new MatchupPlayer()
                {

                    ActualPoints = float.Parse(pointsScored[1]),
                    ProjectedPoints = float.Parse(projectedRight),
                    MatchupPosition = ParseFantasyPosition(fantasyPosition),
                    Player = new NFLPlayer
                    {
                        FullName = fullNameLeft,
                        ShortName = shortNames[1],
                        NFLTeam = team_pos[1][0],
                        NFLPosition = ParseNFLPosition(team_pos[1][1]),
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

        public static NFLPosition ParseNFLPosition(string pos)
        {
            if (pos == "QB") return NFLPosition.QB;
            else if (pos == "RB") return NFLPosition.RB;
            else if (pos == "WR") return NFLPosition.WR;
            else if (pos == "TE") return NFLPosition.TE;
            else if (pos == "DEF") return NFLPosition.DEF;
            else if (pos == "K") return NFLPosition.K;
            else return NFLPosition.Unknown;
        }

        public static FantasyPosition ParseFantasyPosition(string pos)
        {
            if (pos == "QB") return FantasyPosition.QB;
            else if (pos == "RB") return FantasyPosition.RB1;
            else if (pos == "WR") return FantasyPosition.WR1;
            else if (pos == "TE") return FantasyPosition.TE;
            else if (pos == "W/R/T") return FantasyPosition.FLEX;
            else if (pos == "DEF") return FantasyPosition.DEF;
            else if (pos == "K") return FantasyPosition.K;
            else if (pos == "BN") return FantasyPosition.BN;
            else return FantasyPosition.BN;
        }

        public class FantasySeason
        {
            public int Year { get; set; }
            public List<FantasyOwner> Owners { get; set; }
            public List<FantasyMatchup> Matchups { get; set; }
        }

        public class FantasyOwner
        {
            public string ManagerName { get; set; }
            public string TeamName { get; set; }
            public List<FantasyTeam> Weeks { get; set; }

            public FantasyOwner(string managerName, string teamName)
            {
                ManagerName = managerName;
                TeamName = teamName;
                Weeks = new List<FantasyTeam>();
            }
        }

        public class FantasyTeam : IComparable
        {
            public string Week { get; set; }
            public List<MatchupPlayer> Starters { get; set; }
            public List<MatchupPlayer> Bench { get; set; }
            public float Score => Starters.Sum(p => p.ActualPoints);

            public FantasyTeam(string week)
            {
                Week = week;
                Starters = new List<MatchupPlayer>();
                Bench = new List<MatchupPlayer>();
            }

            public void AddPlayer(MatchupPlayer player)
            {
                if (player.MatchupPosition == FantasyPosition.BN)
                    Bench.Add(player);
                else
                {
                    if (player.MatchupPosition == FantasyPosition.RB1 && Starters.Count(s => s.MatchupPosition == FantasyPosition.RB1) > 0)
                        player.MatchupPosition = FantasyPosition.RB2;
                    else if (player.MatchupPosition == FantasyPosition.WR1 && Starters.Count(s => s.MatchupPosition == FantasyPosition.WR1) > 0)
                        player.MatchupPosition = FantasyPosition.WR2;
                    Starters.Add(player);
                }
            }

            public List<MatchupPlayer> IdealTeam()
            {
                var tempTeam = new List<MatchupPlayer>();
                var roster = Starters.Union(Bench).ToList();
                foreach (var position in ValidRoster)
                {
                    var player = roster.Where(p => p.Player.IsEligible(position)).Max();
                    tempTeam.Add(player);
                    roster.Remove(player);
                }

                return tempTeam;
            }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                FantasyTeam otherTeam = obj as FantasyTeam;

                if (otherTeam != null)
                    return Score.CompareTo(otherTeam.Score);
                else
                    throw new ArgumentException("Object is not a FantasyTeam");
            }
        }

        public class NFLPlayer
        {
            public string FullName { get; set; }
            public string ShortName { get; set; }
            public string NFLTeam { get; set; }
            public NFLPosition NFLPosition { get; set; }
            public bool IsEligible(FantasyPosition position)
            {
                if ((int)position / (int)NFLPosition == 10)
                    return true;
                else if (position == FantasyPosition.FLEX &&
                    (NFLPosition == NFLPosition.RB ||
                    NFLPosition == NFLPosition.WR ||
                    NFLPosition == NFLPosition.TE))
                    return true;
                else return false;
            }
        }

        public class MatchupPlayer : IComparable
        {
            public NFLPlayer Player { get; set; }
            public FantasyPosition MatchupPosition { get; set; }
            public float ProjectedPoints { get; set; }
            public float ActualPoints { get; set; }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                MatchupPlayer otherPlayer = obj as MatchupPlayer;

                if (otherPlayer != null)
                    return ActualPoints.CompareTo(otherPlayer.ActualPoints);
                else
                    throw new ArgumentException("Object is not a MatchupPlayer");
            }
        }

        public class FantasyMatchup
        {
            public FantasyTeam LeftTeam { get; set; }
            public FantasyTeam RightTeam { get; set; }

            public int Winner => LeftTeam.CompareTo(RightTeam);
        }

        public enum NFLPosition
        {
            QB = 1,
            RB = 2,
            WR = 3,
            TE = 4,
            DEF = 5,
            K = 6,
            Unknown = 99
        }

        public enum FantasyPosition
        {
            QB = 10,
            RB1 = 20,
            RB2 = 21,
            WR1 = 30,
            WR2 = 31,
            TE = 40,
            DEF = 50,
            K = 60,
            FLEX = 99,
            BN = 100
        }

        public static readonly List<FantasyPosition> ValidRoster = new List<FantasyPosition>
        {
            FantasyPosition.QB,
            FantasyPosition.RB1,
            FantasyPosition.RB2,
            FantasyPosition.WR1,
            FantasyPosition.WR2,
            FantasyPosition.TE ,
            FantasyPosition.DEF,
            FantasyPosition.K,
            FantasyPosition.FLEX,
        };
    }
}
