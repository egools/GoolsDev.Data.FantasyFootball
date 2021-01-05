using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFantasyService;

namespace FantasyParser
{
    public class App
    {
        private readonly IConfiguration _config;
        private readonly YahooService _yahooService;

        public App(
            IConfiguration config,
            YahooService yahooService)
        {
            _config = config;
            _yahooService = yahooService;
        }
        public void Run()
        {
            Console.WriteLine("Hello from App.cs");
            Console.WriteLine(_config.GetConnectionString("GoolsDevSqlConnection"));
            //var a = new YahooService();
            //a.GetSeasonWithSettings(2019, 724919);
            //ParseSeasons();
            //var a = new HttpClient();
            //var token = "token";
            //a.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //var response = await a.GetAsync("https://fantasysports.yahooapis.com/fantasy/v2/league/399.l.299900/teams/roster;weeks=1?format=json");
            //var data = await response.Content.ReadAsStringAsync();
        }
    }
}
