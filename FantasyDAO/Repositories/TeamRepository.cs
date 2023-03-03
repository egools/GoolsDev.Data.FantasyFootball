using FantasyDAO.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyDAO.Repositories
{
    public class TeamRepository : GenericRepository<Team>, IRepository<Team>
    {
        public TeamRepository(DbContext context) : base(context) { }
    }
}