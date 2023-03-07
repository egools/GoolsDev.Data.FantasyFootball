using FantasyRepo.Cosmos.Interfaces;
using FantasyRepo.Cosmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRepo.Cosmos.Concretes
{
    internal class SeasonRepository : IRepository<Season>
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Season> Find(Expression<Func<Season, bool>>? filter = null, Func<IQueryable<Season>, IOrderedQueryable<Season>>? orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Season Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Season entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Season entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
