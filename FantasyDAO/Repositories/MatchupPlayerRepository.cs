using FantasyDAO.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyDAO.Repositories
{
    public class MatchupPlayerRepository : GenericRepository<MatchupPlayer>, IRepository<MatchupPlayer>
    {
        public MatchupPlayerRepository(DbContext context) : base(context) { }
    }
}