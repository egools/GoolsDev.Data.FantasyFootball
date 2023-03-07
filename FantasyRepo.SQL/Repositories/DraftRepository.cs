using FantasyRepo.SQL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyRepo.SQL.Repositories
{
    public class DraftRepository : GenericRepository<Draft>, IRepository<Draft>
    {
        public DraftRepository(DbContext context) : base(context) { }
    }
}