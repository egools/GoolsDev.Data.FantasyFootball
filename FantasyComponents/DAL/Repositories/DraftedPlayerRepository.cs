using FantasyComponents;
using Microsoft.EntityFrameworkCore;

namespace FantasyComponents.DAL
{
    public class DraftedPlayerRepository : GenericRepository<DraftedPlayer>, IRepository<DraftedPlayer>
    {
        public DraftedPlayerRepository(DbContext context) : base(context) { }
    }
}