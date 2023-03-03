using FantasyDAO.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyDAO.Repositories
{
    public class EloRatingRepository : GenericRepository<EloRating>, IRepository<EloRating>
    {
        public EloRatingRepository(DbContext context) : base(context) { }
    }
}