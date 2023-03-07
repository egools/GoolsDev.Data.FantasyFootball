using System.Linq.Expressions;

namespace FantasyRepo.Cosmos.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(string id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");
        TEntity Get(string id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}
