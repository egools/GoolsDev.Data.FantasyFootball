using FantasyRepo.SQL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyRepo.SQL.Repositories
{
    public class MatchupRosterRepository : GenericRepository<Roster>, IRepository<Roster>
    {
        public MatchupRosterRepository(DbContext context) : base(context) { }
    }
}