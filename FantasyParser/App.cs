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
        public void Run()
        {
            //var text = File.ReadAllText(@"C:\Users\Eric\source\repos\egools\app_data\yahoo_api_leagueSettings\2020.json");
            var league = _uow.LeagueRepo.FindById("10");
            _uow.LeagueRepo.Insert(new League("BMGC2"));
            _uow.Save();
            //var result = _yahooService.CallYahooFantasyApi("https://fantasysports.yahooapis.com/fantasy/v2/league/399.l.299900;out=draftresults,settings,scoreboard,standings?format=json").Result;
            var leagueResult = _yahooService.GetSeasonWithSettings(2020, 299900).Result;
        }
    }
}
