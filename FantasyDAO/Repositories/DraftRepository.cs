using FantasyDAO.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyDAO.Repositories
{
    public class DraftRepository : GenericRepository<Draft>, IRepository<Draft>
    {
        public DraftRepository(DbContext context) : base(context) { }
    }
}