using FantasyComponents;
using Microsoft.EntityFrameworkCore;

namespace FantasyComponents.DAL
{
    public class MatchupRosterRepository : GenericRepository<MatchupRoster>, IRepository<MatchupRoster>
    {
        public MatchupRosterRepository(DbContext context) : base(context) { }
    }
}