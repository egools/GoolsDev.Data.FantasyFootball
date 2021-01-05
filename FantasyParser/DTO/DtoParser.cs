using FantasyComponents.DAL;
using FantasyComponents;
using System;
using System.Linq;

namespace FantasyParser.DTO
{
    public static class DtoParser
    {
        private static readonly FantasyFootballUnitOfWork _repo = new FantasyFootballUnitOfWork(new FantasyFootballContextLocal("BMGC"));
        public static void AddDataFromManagerDto(ManagersDto managersDto)
        {
            var gameKey = "399";
            var season = _repo.SeasonRepo.FindById($"{gameKey}.l.{managersDto.YahooLeagueId}")
                ?? _repo.LeagueRepo.AddNewSeason(short.Parse(managersDto.SeasonYear), managersDto.YahooLeagueId, managersDto.LeagueName);

            foreach (ManagerDto managerDto in managersDto.Managers)
            {
                var manager = _repo.ManagerRepo.FindById(managerDto.YahooManagerId)
                    ?? _repo.ManagerRepo.AddNewManager(managerDto.YahooManagerId, managerDto.ManagerName);

                var managerSeason = season.Teams.FirstOrDefault(ms => ms.ManagerId == manager.ManagerId);
                if (managerSeason is null)
                {
                    managerSeason = new Team(managerDto.TeamName, short.Parse(managersDto.SeasonYear))
                    {
                        MovesMade = managerDto.MovesMade,
                        TradesMade = managerDto.TradesMade,
                    };
                    manager.ManagerSeasons.Add(managerSeason);
                    season.Teams.Add(managerSeason);
                }
                else
                {
                    managerSeason.MovesMade = managerDto.MovesMade;
                    managerSeason.TradesMade = managerDto.TradesMade;
                }
            }
            _repo.Save();
        }
        public static void AddDataFromDraftDto(DraftDto draftDto)
        {
            var gameKey = "399";
            var season = _repo.LeagueRepo.Find(includeProperties: "Seasons.Draft,Seasons.ManagerSeasons.DraftedPlayers")
                .FirstOrDefault()?
                .Seasons
                .Where(s => s.SeasonId == $"{gameKey}.l.{draftDto.YahooLeagueId}")
                .FirstOrDefault()
                ?? _repo.LeagueRepo.AddNewSeason(short.Parse(draftDto.SeasonYear), draftDto.YahooLeagueId, draftDto.LeagueName);

            var draft = new Draft($"{gameKey}.l.{draftDto.YahooLeagueId}", draftDto.IsAuction ? DraftType.Auction : DraftType.Snake);
            foreach (var teamDraft in draftDto.Teams)
            {
                var managerSeason = season.Teams.FirstOrDefault(ms => ms.TeamName == teamDraft.TeamName); //TODO: need to update script to get yahooManagerName here instead of using teamname
                if (managerSeason is null)
                {
                    throw new ArgumentException("Team name not found in season.");
                }
                foreach (var playerDto in teamDraft.Players)
                {
                    var player = new DraftedPlayer(playerDto.Round, playerDto.DraftPosition, playerDto.Price);
                    var nflPlayer = _repo.NFLPlayerRepo.FindById(playerDto.YahooPlayerId.ToString())
                        ?? _repo.NFLPlayerRepo.AddNewNFLPlayer(playerDto.YahooPlayerId.ToString(), playerDto.FullName, playerDto.ShortName, playerDto.NFLPosition);
                    managerSeason.DraftedPlayers.Add(player);
                }
            }
            _repo.Save();
        }
        public static void AddDataFromMatchupDto(MatchupDto matchupDto)
        {
            var gameKey = "399";
            var season = _repo.LeagueRepo.Find(includeProperties: "Seasons.ManagerSeasons.Rosters,Seasons.Matchups")
                .FirstOrDefault()?
                .Seasons
                .Where(s => s.SeasonId ==$"{gameKey}.l.{matchupDto.YahooLeagueId}")
                .FirstOrDefault()
                ?? _repo.LeagueRepo.AddNewSeason(short.Parse(matchupDto.SeasonYear), matchupDto.YahooLeagueId, matchupDto.LeagueName);

            var managerSeasonLeft = _repo.ManagerRepo.GetManagersSeasons(matchupDto.LeftTeam.YahooManagerId, "MatchupRosters")
                .Where(team => team.Year == short.Parse(matchupDto.SeasonYear) && team.SeasonId == season.SeasonId)
                .FirstOrDefault()
                ?? CreateManagerSeasonFromTeamDto(matchupDto.LeftTeam, ref season);

            var managerSeasonRight = _repo.ManagerRepo.GetManagersSeasons(matchupDto.RightTeam.YahooManagerId, "MatchupRosters")
                .Where(team => team.Year == short.Parse(matchupDto.SeasonYear) && team.SeasonId == season.SeasonId)
                .FirstOrDefault()
                ?? CreateManagerSeasonFromTeamDto(matchupDto.LeftTeam, ref season);

            var matchup = new Matchup(byte.Parse(matchupDto.Week));
            AddPlayersFromTeamDto(matchupDto.LeftTeam, matchup.Roster1);
            AddPlayersFromTeamDto(matchupDto.RightTeam, matchup.Roster2);
            managerSeasonLeft.Rosters.Add(matchup.Roster1);
            managerSeasonRight.Rosters.Add(matchup.Roster2);
            season.Matchups.Add(matchup);
            _repo.Save();
        }
        public static void AddPlayersFromTeamDto(TeamDto team, MatchupRoster roster)
        {
            roster.ActualScore = team.ActualScore;
            roster.ProjectedScore = team.ProjectedScore;
            foreach (var playerDto in team.Players)
            {
                var nflPlayer = _repo.NFLPlayerRepo.FindById(playerDto.YahooPlayerId.ToString())
                    ?? _repo.NFLPlayerRepo.AddNewNFLPlayer(playerDto.YahooPlayerId.ToString(), playerDto.FullName, playerDto.ShortName, playerDto.NFLPosition);
                if (string.IsNullOrEmpty(nflPlayer.ShortName))
                {
                    nflPlayer.ShortName = playerDto.ShortName;
                }
                var player = new MatchupPlayer(nflPlayer, playerDto.ProjectedPoints, playerDto.PointsScored, playerDto.FantasyPosition);
                roster.MatchupPlayers.Add(player);
            }
        }

        public static Team CreateManagerSeasonFromTeamDto(TeamDto team, ref Season season)
        {
            var manager = _repo.ManagerRepo.FindById(team.YahooManagerId) ?? _repo.ManagerRepo.AddNewManager(team.YahooManagerId, team.ManagerName);
            var managerSeason = new Team(team.TeamName, season.Year);
            season.Teams.Add(managerSeason);
            manager.ManagerSeasons.Add(managerSeason);
            _repo.Save();
            return managerSeason;
        }
    }
}
