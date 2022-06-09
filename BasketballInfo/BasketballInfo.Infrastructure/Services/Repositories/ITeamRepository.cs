using BasketballInfo.Domain;
using System.Threading.Tasks;

namespace BasketballInfo.Infrastructure.Services.Repositories
{
    public interface ITeamRepository
    {
        Task<Team> GetTeamById(int teamId);
    }
}
