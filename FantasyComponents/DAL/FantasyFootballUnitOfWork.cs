using FantasyComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyComponents.DAL
{
    public class FantasyFootballUnitOfWork : IDisposable, IFantasyFootballUnitOfWork
    {
        public FantasyFootballUnitOfWork(FantasyFootballContext context)
        {
            this.context = context;
        }

        private readonly FantasyFootballContext context;
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

        public LeagueRepository LeagueRepo { get => leagueRepository ??= new LeagueRepository(context); }
        public SeasonRepository SeasonRepo { get => seasonRepository ??= new SeasonRepository(context); }
        public ManagerRepository ManagerRepo { get => managerRepository ??= new ManagerRepository(context); }
        public TeamRepository TeamRepo { get => teamRepository ??= new TeamRepository(context); }
        public MatchupRepository MatchupRepo { get => matchupRepository ??= new MatchupRepository(context); }
        public MatchupRosterRepository RosterRepo { get => rosterRepository ??= new MatchupRosterRepository(context); }
        public MatchupPlayerRepository MatchupPlayerRepo { get => matchupPlayerRepository ??= new MatchupPlayerRepository(context); }
        public NFLPlayerRepository NFLPlayerRepo { get => nflPlayerRepository ??= new NFLPlayerRepository(context); }
        public DraftRepository DraftRepo { get => draftRepository ??= new DraftRepository(context); }
        public DraftedPlayerRepository DraftedPlayerRepo { get => draftedPlayerRepository ??= new DraftedPlayerRepository(context); }
        public EloRatingRepository RatingRepo { get => ratingRepository ??= new EloRatingRepository(context); }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}