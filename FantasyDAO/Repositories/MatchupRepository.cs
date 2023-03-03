using FantasyDAO.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyDAO.Repositories
{
    public class MatchupRepository : GenericRepository<Matchup>, IRepository<Matchup>
    {
        public MatchupRepository(DbContext context) : base(context)
        {
            this.context.ChangeTracker.Tracked += OnMatchupAdded;
        }

        public static void OnMatchupAdded(object sender, EntityTrackedEventArgs e)
        {
            if (!e.FromQuery && e.Entry.State == EntityState.Added && e.Entry.Entity is Matchup matchup)
            {
                matchup.Roster1.MatchupId = matchup.MatchupId;
                matchup.Roster2.MatchupId = matchup.MatchupId;
            }
        }
    }
}
