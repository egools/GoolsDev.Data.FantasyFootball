using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FantasyComponents.DAL
{
    public class LeagueRepository : GenericRepository<League>, IRepository<League>
    {
        public LeagueRepository(DbContext context) : base(context) { }
        public Season AddNewSeason(short seasonYear, int yahooLeagueId, string leagueName)
        {
            var season = new Season(seasonYear, yahooLeagueId, leagueName);
            Find(null, null, "Seasons").First().Seasons.Add(season);
            return season;
        }
    }
}