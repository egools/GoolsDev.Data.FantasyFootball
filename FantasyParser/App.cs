using FantasyComponents;
using FantasyComponents.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YahooFantasyService;
using static YahooFantasyService.YahooEnums;

namespace FantasyParser
{
    public class App
    {
        private readonly IConfiguration _config;
        private readonly YahooService _yahooService;
        private readonly FantasyFootballUnitOfWork _uow;

        public App(
            IConfiguration config,
            YahooService yahooService,
            FantasyFootballUnitOfWork uow)
        {
            _config = config;
            _yahooService = yahooService;
            _uow = uow;
        }
        public async Task Run()
        {
            try
            {

                //var text = File.ReadAllText(@"C:\Users\Eric\source\repos\egools\app_data\yahoo_api_leagueSettings\2020.json");
                //var league = _uow.LeagueRepo.FindById("10");
                //_uow.LeagueRepo.Insert(new League("BMGC2"));
                //_uow.Save();
                //var result = _yahooService.CallYahooFantasyApi("https://fantasysports.yahooapis.com/fantasy/v2/league/399.l.299900;out=draftresults,settings,scoreboard,standings?format=json").Result;
                var settings = await _yahooService.GetLeagueSettings(2020, 299900);
                var league = await _yahooService.GetLeague("399.l.299900", AllLeagueResources);
                var leagues = await _yahooService.GetLeagues(new List<string> { "399.l.299900", "390.l.724919" }, AllLeagueResources);
                var team = await _yahooService.GetTeam("399.l.299900.t.1");
                var teams = await _yahooService.GetTeams(new List<string> { "399.l.299900.t.1", "390.l.724919.t.1" });
                var teamStats = await _yahooService.GetTeamStats("399.l.299900.t.11", CoverageType.Week, 1);
                var teamAndRoster = await _yahooService.GetTeamRosterWithStats("399.l.299900.t.1", 1);
                var player = await _yahooService.GetPlayer("399.p.31002", PlayerSubresource.Stats);
                var players = await _yahooService.GetPlayers(new List<string> { "399.p.31002", "399.p.8780" }, PlayerSubresource.Stats);
            }
            catch (YahooServiceException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ErrorResult.Description);
                Console.ResetColor();
            }
        }
    }
}
