using FantasyComponents;
using Microsoft.EntityFrameworkCore;

namespace FantasyComponents.DAL
{
    public class TeamRepository : GenericRepository<Team>, IRepository<Team>
    {
        public TeamRepository(DbContext context) : base(context) { }
    }
}