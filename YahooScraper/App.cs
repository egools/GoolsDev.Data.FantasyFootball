using FantasyRepo.SQL;
using YahooScraper.Factories;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using YahooFantasyService;
using static YahooFantasyService.YahooEnums;

namespace YahooScraper;
public class App
{
    private readonly IConfiguration _config;
    private readonly YahooService _yahooService;
    private readonly FantasyFootballUnitOfWork _repo;

    public App(
        IConfiguration config,
        YahooService yahooService,
        FantasyFootballUnitOfWork uow)
    {
        _config = config;
        _yahooService = yahooService;
        _repo = uow;
    }

    public async Task Run()
    {
        try
        {
            var yLeagueResult = await _yahooService.GetLeague("399.l.299900", AllLeagueResources);
            var league = LeagueFactory.FromYahooDto(yLeagueResult.League);
            var season = SeasonFactory.FromYahooDto(yLeagueResult.League);
            var draft = DraftFactory.FromYahooDto(yLeagueResult.League);
            season.Draft = draft;
            league.Seasons.Add(season);

            //var leagues = await _yahooService.GetLeagues(new List<string> { "399.l.299900", "390.l.724919" }, AllLeagueResources);
            //var team = await _yahooService.GetTeam("399.l.299900.t.1");
            //var teams = await _yahooService.GetTeams(new List<string> { "
            //399.l.299900.t.1", "390.l.724919.t.1" });
            //var teamStats = await _yahooService.GetTeamStats("399.l.299900.t.11", CoverageType.Week, 1);
            //var teamAndRoster = await _yahooService.GetTeamRosterWithStats("399.l.299900.t.1", 1);
            //var player = await _yahooService.GetPlayer("399.p.31002", PlayerSubresource.Stats);
            //var players = await _yahooService.GetPlayers(new List<string> { "399.p.31002", "399.p.8780" }, PlayerSubresource.Stats);
        }
        catch (YahooServiceException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.ErrorResult.Description);
            Console.ResetColor();
        }
    }
}