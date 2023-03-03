using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FantasyComponents.DAL
{
    public class LeagueRepository : GenericRepository<League>, IRepository<League>
    {
        public LeagueRepository(DbContext context) : base(context)
        {
        }
    }
}