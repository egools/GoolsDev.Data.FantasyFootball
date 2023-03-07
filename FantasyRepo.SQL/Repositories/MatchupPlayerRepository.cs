using FantasyRepo.SQL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyRepo.SQL.Repositories
{
    public class MatchupPlayerRepository : GenericRepository<MatchupPlayer>, IRepository<MatchupPlayer>
    {
        public MatchupPlayerRepository(DbContext context) : base(context) { }
    }
}