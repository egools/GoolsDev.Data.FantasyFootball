using FantasyRepo.SQL.Interfaces;
using FantasyRepo.SQL.Repositories;
using System;
using System.Threading.Tasks;

namespace FantasyRepo.SQL
{
    public class FantasyFootballUnitOfWork : IDisposable, IFantasyFootballUnitOfWork
    {
        public FantasyFootballUnitOfWork(FantasyFootballContext context)
        {
            fantasyFootballContext = context;
        }

        private readonly FantasyFootballContext fantasyFootballContext;
        private LeagueRepository leagueRepository;
        private SeasonRepository seasonRepository;
        private ManagerRepository managerRepository;
        private TeamRepository teamRepository;
        private MatchupRepository matchupRepository;
        private MatchupRosterRepository rosterRepository;
        private MatchupPlayerRepository matchupPlayerRepository;
        private NFLPlayerRepository nflPlayerRepository;
        private DraftRepository draftRepository;
        private DraftedPlayerRepository draftedPlayerRepository;
        private EloRatingRepository ratingRepository;

        public LeagueRepository LeagueRepo { get => leagueRepository ??= new LeagueRepository(fantasyFootballContext); }
        public SeasonRepository SeasonRepo { get => seasonRepository ??= new SeasonRepository(fantasyFootballContext); }
        public ManagerRepository ManagerRepo { get => managerRepository ??= new ManagerRepository(fantasyFootballContext); }
        public TeamRepository TeamRepo { get => teamRepository ??= new TeamRepository(fantasyFootballContext); }
        public MatchupRepository MatchupRepo { get => matchupRepository ??= new MatchupRepository(fantasyFootballContext); }
        public MatchupRosterRepository RosterRepo { get => rosterRepository ??= new MatchupRosterRepository(fantasyFootballContext); }
        public MatchupPlayerRepository MatchupPlayerRepo { get => matchupPlayerRepository ??= new MatchupPlayerRepository(fantasyFootballContext); }
        public NFLPlayerRepository NFLPlayerRepo { get => nflPlayerRepository ??= new NFLPlayerRepository(fantasyFootballContext); }
        public DraftRepository DraftRepo { get => draftRepository ??= new DraftRepository(fantasyFootballContext); }
        public DraftedPlayerRepository DraftedPlayerRepo { get => draftedPlayerRepository ??= new DraftedPlayerRepository(fantasyFootballContext); }
        public EloRatingRepository RatingRepo { get => ratingRepository ??= new EloRatingRepository(fantasyFootballContext); }

        public void Save()
        {
            fantasyFootballContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await fantasyFootballContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    fantasyFootballContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}