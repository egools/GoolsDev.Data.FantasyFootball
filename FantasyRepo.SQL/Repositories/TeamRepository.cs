using FantasyRepo.SQL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyRepo.SQL.Repositories
{
    public class TeamRepository : GenericRepository<Team>, IRepository<Team>
    {
        public TeamRepository(DbContext context) : base(context) { }
    }
}