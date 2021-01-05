using FantasyComponents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyComponents.DAL
{
    public class SeasonRepository : GenericRepository<Season>, IRepository<Season>
    {
        public SeasonRepository(DbContext context) : base(context) { }
    }
}
