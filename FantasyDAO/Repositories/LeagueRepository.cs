using FantasyDAO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FantasyDAO.Repositories
{
    public class LeagueRepository : GenericRepository<League>, IRepository<League>
    {
        public LeagueRepository(DbContext context) : base(context)
        {
        }
    }
}