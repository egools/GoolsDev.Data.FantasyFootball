using FantasyComponents;
using Microsoft.EntityFrameworkCore;

namespace FantasyComponents.DAL
{
    public class DraftRepository : GenericRepository<Draft>, IRepository<Draft>
    {
        public DraftRepository(DbContext context) : base(context) { }
    }
}