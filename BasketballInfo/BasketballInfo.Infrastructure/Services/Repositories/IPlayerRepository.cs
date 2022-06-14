﻿using BasketballInfo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Infrastructure.Services.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllPlayersForTeamAsync(int teamId);
        Task<Player> GetPlayerByIdAsync(int teamId, int playerId);
        //Task CreatePlayerByIdAsync(int teamId, Player player);
        //bool UpdatePlayerByPlayerIdAsync(Player player);
        //void DeletePlayerByPlayerIdAsync(Player player);
    }
}