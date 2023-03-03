using System.Threading.Tasks;
using FantasyDAO.Repositories;

namespace FantasyDAO.Interfaces
{
    public interface IFantasyFootballUnitOfWork
    {
        DraftedPlayerRepository DraftedPlayerRepo { get; }
        DraftRepository DraftRepo { get; }
        LeagueRepository LeagueRepo { get; }
        ManagerRepository ManagerRepo { get; }
        TeamRepository TeamRepo { get; }
        MatchupPlayerRepository MatchupPlayerRepo { get; }
        MatchupRepository MatchupRepo { get; }
        NFLPlayerRepository NFLPlayerRepo { get; }
        EloRatingRepository RatingRepo { get; }
        MatchupRosterRepository RosterRepo { get; }
        SeasonRepository SeasonRepo { get; }

        void Dispose();
        void Save();
        Task SaveAsync();
    }
}