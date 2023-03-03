using FantasyDAO.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyDAO.Repositories
{
    public class DraftedPlayerRepository : GenericRepository<DraftedPlayer>, IRepository<DraftedPlayer>
    {
        public DraftedPlayerRepository(DbContext context) : base(context) { }
    }
}