using FantasyComponents;
using Microsoft.EntityFrameworkCore;

namespace FantasyComponents.DAL
{
    public class EloRatingRepository : GenericRepository<EloRating>, IRepository<EloRating>
    {
        public EloRatingRepository(DbContext context) : base(context) { }
    }
}