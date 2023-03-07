using FantasyRepo.SQL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FantasyRepo.SQL.Repositories
{
    public class ManagerRepository : GenericRepository<Manager>, IRepository<Manager>
    {
        public ManagerRepository(DbContext context) : base(context) { }
        public Manager AddNewManager(string yahooManagerId, string managerName)
        {
            var manager = new Manager(yahooManagerId, managerName);
            Insert(manager);
            return manager;
        }
        public IEnumerable<Team> GetManagersSeasons(string yahooManagerId, string include)
        {
            var includes = include.Split(',', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < includes.Length; i++)
            {
                if (!includes[i].StartsWith("ManagerSeason"))
                    includes[i] = "ManagerSeason." + includes[i];
            }
            return FindById(yahooManagerId).ManagerSeasons;
        }
    }
}
