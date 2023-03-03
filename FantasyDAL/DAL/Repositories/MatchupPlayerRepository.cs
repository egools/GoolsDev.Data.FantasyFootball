using FantasyComponents;
using Microsoft.EntityFrameworkCore;

namespace FantasyComponents.DAL
{
    public class MatchupPlayerRepository : GenericRepository<MatchupPlayer>, IRepository<MatchupPlayer>
    {
        public MatchupPlayerRepository(DbContext context) : base(context) { }
    }
}