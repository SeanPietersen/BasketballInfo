using BasketballInfo.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public interface IPlayerContract
    {
        IEnumerable<PlayerDto> GetAllPlayersForTeam(int teamId);
        PlayerDto GetPlayerById(int teamId, int playerId);
        //Task<PlayerDto> CreatePlayerById(int teamId, CreatePlayerDto playerDto);
        //Task<PlayerDto> UpdatePlayerByPlayerId(int teamId, int playerId, PlayerForUpdateDto playerDto);
        //Task<PlayerDto> DeletePlayerByPlayerId(int teamId, int playerId);
    }
}
