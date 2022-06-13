using BasketballInfo.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public interface ITeamContract
    {
        Task<IEnumerable<TeamDto>> GetAllTeams();
        Task<TeamDto> GetTeamById(int teamId, bool includePlayers = false, bool includeCoaches = false);
    }
}
