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
    internal class SeasonRepository : IRepository<League>
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<League> Find(Expression<Func<League, bool>>? filter = null, Func<IQueryable<League>, IOrderedQueryable<League>>? orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public League Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(League entity)
        {
            throw new NotImplementedException();
        }

        public void Update(League entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
