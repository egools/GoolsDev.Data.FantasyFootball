using FantasyRepo.SQL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyRepo.SQL.Repositories
{
    public class DraftedPlayerRepository : GenericRepository<DraftedPlayer>, IRepository<DraftedPlayer>
    {
        public DraftedPlayerRepository(DbContext context) : base(context) { }
    }
}