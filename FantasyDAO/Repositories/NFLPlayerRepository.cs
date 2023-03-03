using FantasyDAO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FantasyDAO.Repositories
{
    public class NFLPlayerRepository : GenericRepository<NFLPlayer>, IRepository<NFLPlayer>
    {
        public NFLPlayerRepository(DbContext context) : base(context) { }
        public NFLPlayer AddNewNFLPlayer(string playerId, string fullName, string shortName)
        {
            var player = new NFLPlayer(playerId, fullName, shortName);
            Insert(player);
            return player;
        }
    }
}