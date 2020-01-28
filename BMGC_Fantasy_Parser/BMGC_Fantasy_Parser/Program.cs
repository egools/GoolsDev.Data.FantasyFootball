using AngleSharp;
using AngleSharp.Dom;
using System;
using System.IO;
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

            //tr .player .ysf-player-name a    => short name
            //tr .player .ysf-player-name span => team - pos
            //tr .player .ysf-game-status a[0] => score / result
            //tr .player .ysf-game-status a[1] => opponent

            //tr .Fw-b a.pps =>                points scored
            //td[2/8] div =>                   projected points
        }

        public static async Task<IDocument> GetDocument(string path)
        {
            var context = BrowsingContext.New(Configuration.Default);
            var html = File.ReadAllText(path);
            return await context.OpenAsync(req => req.Content(html)); ;
        }
    }
}
