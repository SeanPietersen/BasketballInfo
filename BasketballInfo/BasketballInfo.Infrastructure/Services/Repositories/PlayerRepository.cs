using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballInfo.Infrastructure.Services.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly BasketballInfoContext _context;

        public PlayerRepository(BasketballInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Player>> GetAllPlayersForTeamAsync(int teamId)
        {
            return await _context.Players.Where(prop => prop.TeamId == teamId).ToListAsync();
        }

        //public async Task<Player> GetPlayerByPlayerIdAsync(int teamId, int playerId)
        //{
        //    return await _context.Players.Where(c => c.TeamId == teamId && c.PlayerId == playerId).FirstOrDefaultAsync();
        //}

        //public async Task CreatePlayerByPlayerIdAsync(int teamId, Player player)
        //{
        //    var teamToReturn = await GetTeamByTeamIdAsync(teamId, false, false);
        //    if (teamToReturn != null)
        //    {
        //        teamToReturn.Player.Add(player);
        //    }
        //}

        //public bool UpdatePlayerByPlayerIdAsync(Player player)
        //{
        //    var entity = _context.Players.Update(player);

        //    if (entity == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public void DeletePlayerByPlayerIdAsync(Player player)
        //{
        //    _context.Players.Remove(player);
        //}
    }
}
