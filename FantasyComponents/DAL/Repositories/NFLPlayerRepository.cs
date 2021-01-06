using FantasyComponents;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FantasyComponents.DAL
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