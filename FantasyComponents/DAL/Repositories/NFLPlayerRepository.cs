using FantasyComponents;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FantasyComponents.DAL
{
    public class NFLPlayerRepository : GenericRepository<NFLPlayer>, IRepository<NFLPlayer>
    {
        public NFLPlayerRepository(DbContext context) : base(context) { }
        public NFLPlayer AddNewNFLPlayer(string playerId, string fullName, string shortName, NFLPosition nflPosition)
        {
            var player = new NFLPlayer(playerId, fullName, shortName)
            {
                NFLPosition = nflPosition
            };
            Insert(player);
            return player;
        }
    }
}