using BasketballInfo.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public interface IPlayerContract
    {
        IEnumerable<PlayerDto> GetAllPlayersByTeamId(int teamId);
        PlayerDto GetPlayerByPlayerId(int teamId, int playerId);
        Task<PlayerDto> CreatePlayerByPlayerId(int teamId, PlayerForCreationDto playerDto);
        Task<PlayerDto> UpdatePlayerByPlayerId(int teamId, int playerId, PlayerForUpdateDto playerDto);
        Task<PlayerDto> DeletePlayerByPlayerId(int teamId, int playerId);
    }
}
