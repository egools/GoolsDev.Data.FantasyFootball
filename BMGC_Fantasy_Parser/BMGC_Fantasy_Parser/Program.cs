using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BMGC_Fantasy_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = GetDocument(@"C:\Users\egoolsby\Documents\0_MyFiles\BMGC_Fantasy_Stats\HtmlSource\2019\Week1\gools_snow.html").Result;
            var starters = document.QuerySelectorAll("#mathcups #statTable1 tbody tr:not(.Last)");
            var bench = document.QuerySelectorAll("#bench-table #statTable2 tbody tr:not(.Last)");

            //data-stat-note-id on clickable stat columns (.has-stat-note) includes ID for stat breakdown with player name ("#pps-31896")
            //e.g. document.querySelector("#pps-31896 h2").innerText => "DK Metcalf Stat Breakdown"

            //td[5] => row player position

            //.player .ysf-player-name a    => short name
            //.player .ysf-player-name span => team - pos
            //.player .ysf-game-status a[0] => score / result
            //.player .ysf-game-status a[1] => opponent

            //tr .Fw-b a.pps =>                points scored
            //td[2/8] div =>                   projected points
        }

        public static async Task<IDocument> GetDocument(string path)
        {
            var context = BrowsingContext.New(Configuration.Default);
            var html = File.ReadAllText(path);
            return await context.OpenAsync(req => req.Content(html)); ;
        }

        public class FantasyOwner
        {
            public string OwnerName { get; set; }
            public string TeamName { get; set; }
            public List<FantasyTeam> Weeks { get; set; }
        }

        public class FantasyTeam
        {
            public FantasyPlayer QB { get; set; }
            public FantasyPlayer RB1 { get; set; }
            public FantasyPlayer RB2 { get; set; }
            public FantasyPlayer WR1 { get; set; }
            public FantasyPlayer WR2 { get; set; }
            public FantasyPlayer TE { get; set; }
            public FantasyPlayer FLEX { get; set; }
            public FantasyPlayer DEF { get; set; }
            public FantasyPlayer K { get; set; }
            public List<FantasyPlayer> Bench { get; set; }
            public float Score =>
                QB.ActualPoints +
                RB1.ActualPoints +
                RB2.ActualPoints +
                WR1.ActualPoints +
                WR2.ActualPoints +
                TE.ActualPoints +
                FLEX.ActualPoints +
                DEF.ActualPoints +
                K.ActualPoints;
        }

        public class FantasyPlayer
        {
            public string FullName { get; set; }
            public string ShortName { get; set; }
            public string Position { get; set; }
            public float ProjectedPoints { get; set; }
            public float ActualPoints { get; set; } 
        }

        public class FantasyMatchup
        {
            public FantasyTeam LeftTeam { get; set; }
            public FantasyTeam RightTeam { get; set; }

        }
    }
}
