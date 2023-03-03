using FantasyDAO.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyDAO.Repositories
{
    public class MatchupRosterRepository : GenericRepository<Roster>, IRepository<Roster>
    {
        public MatchupRosterRepository(DbContext context) : base(context) { }
    }
}