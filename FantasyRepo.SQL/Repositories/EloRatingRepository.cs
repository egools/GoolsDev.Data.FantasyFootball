using FantasyRepo.SQL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyRepo.SQL.Repositories
{
    public class EloRatingRepository : GenericRepository<EloRating>, IRepository<EloRating>
    {
        public EloRatingRepository(DbContext context) : base(context) { }
    }
}