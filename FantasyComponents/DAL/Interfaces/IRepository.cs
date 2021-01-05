using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FantasyComponents.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(string id);
        void Delete(TEntity entityToDelete);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity FindById(string id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}