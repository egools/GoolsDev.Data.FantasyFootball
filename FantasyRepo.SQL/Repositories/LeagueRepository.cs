using FantasyRepo.SQL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FantasyRepo.SQL.Repositories
{
    public class LeagueRepository : GenericRepository<League>, IRepository<League>
    {
        public LeagueRepository(DbContext context) : base(context)
        {
        }
    }
}