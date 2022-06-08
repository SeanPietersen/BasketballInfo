using BasketballInfo.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public interface ICoachContract
    {
        IEnumerable<CoachDto> GetAllCoachesForTeamId(int teamId);
        CoachDto GetCoachByTeamIdAndCoachId(int teamId, int coachId);
        Task<CoachDto> CreateCoachByCoachId(int teamId, CoachForCreationDto coahcDto);
        Task<CoachDto> UpdateCoachByCoachId(int teamId, int coachId, CoachForUpdateDto coahcDto);
        Task<CoachDto> DeleteCoachByCoachId(int teamId, int coachId);
    }
}
