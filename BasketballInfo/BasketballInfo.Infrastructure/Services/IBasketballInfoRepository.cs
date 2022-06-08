using BasketballInfo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Infrastructure.Services
{
    public interface IBasketballInfoRepository
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<bool> TeamForTeamIdExists(int teamId);
        Task<Team> GetTeamByTeamIdAsync(int teamId, bool includePlayers = false, bool includeCoaches = false);
        Task<IEnumerable<Player>> GetAllPlayersByTeamIdAsync(int teamId);
        Task<Player> GetPlayerByPlayerIdAsync(int teamId, int playerId);
        Task CreatePlayerByPlayerIdAsync(int teamId, Player player);
        bool UpdatePlayerByPlayerIdAsync(Player player);
        void DeletePlayerByPlayerIdAsync(Player player);
        Task<IEnumerable<Coach>> GetAllCoachesForTeamIdAsync(int teamId);
        Task<Coach> GetCoachByTeamIdAndCoachIdAsyn(int teamId, int coachId);
        Task CreateCoachByCoachIdAsync(int teamId, Coach coach);
        bool UpdateCoachByCoachIdAsync(Coach coach);
        void DeleteCoachByCoachIdAsync(Coach coach);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> UserForUserIdExists(int userId);
        Task<User> GetUserByUserIdAsync(int userId);
    }
}
