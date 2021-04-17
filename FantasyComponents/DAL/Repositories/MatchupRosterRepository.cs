using FantasyComponents;
using Microsoft.EntityFrameworkCore;

namespace FantasyComponents.DAL
{
    public class MatchupRosterRepository : GenericRepository<Roster>, IRepository<Roster>
    {
        public MatchupRosterRepository(DbContext context) : base(context) { }
    }
}