using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballInfo.Infrastructure.Services
{
    public class BasketballInfoRepository : IBasketballInfoRepository
    {
        private readonly BasketballInfoContext _context;

        public BasketballInfoRepository(BasketballInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams.OrderBy(c => c.Name).ToListAsync();
            
        }

        public async Task<Team> GetTeamByTeamIdAsync(int teamId, bool includePlayers = false, bool includeCoaches = false)
        {
            if (includeCoaches && includeCoaches)
            {
                return await _context.Teams.Include(c => c.Coach).Include(d => d.Player)
                    .Where(c => c.TeamId == teamId).FirstOrDefaultAsync();
            }

            if (includePlayers)
            {
                return await _context.Teams.Include(c => c.Player)
                    .Where(c => c.TeamId == teamId).FirstOrDefaultAsync();
            }

            if(includeCoaches)
            {
                return await _context.Teams.Include(c => c.Coach)
                    .Where(c => c.TeamId == teamId).FirstOrDefaultAsync();
            }            
            return await _context.Teams.Where(c => c.TeamId == teamId).FirstOrDefaultAsync();
        }

        public async Task<bool> TeamForTeamIdExists(int teamId)
        {
            return await _context.Teams.AnyAsync(c => c.TeamId == teamId);
        }

        public async Task<IEnumerable<Player>> GetAllPlayersByTeamIdAsync(int teamId)
        {
            return await _context.Players.Where(prop => prop.TeamId == teamId).ToListAsync();
        }

        public async Task<Player> GetPlayerByPlayerIdAsync(int teamId, int playerId)
        {
            return await _context.Players.Where(c => c.TeamId == teamId && c.PlayerId == playerId).FirstOrDefaultAsync();
        }

        public async Task CreatePlayerByPlayerIdAsync(int teamId, Player player)
        {
            var teamToReturn = await GetTeamByTeamIdAsync(teamId, false, false);
            if(teamToReturn != null)
            {
                teamToReturn.Player.Add(player);
            }
        }

        public  bool UpdatePlayerByPlayerIdAsync(Player player)
        {
            var entity = _context.Players.Update(player);

            if(entity == null)
            {
                return false;
            }
            return true;
        }

        public void DeletePlayerByPlayerIdAsync(Player player)
        {
            _context.Players.Remove(player);
        }

        public async Task<IEnumerable<Coach>> GetAllCoachesForTeamIdAsync(int teamId)
        {
            return await _context.Coaches.Where(c => c.TeamId == teamId).ToListAsync();
        }

        public async Task<Coach> GetCoachByTeamIdAndCoachIdAsyn(int teamId, int coachId)
        {
            return await _context.Coaches.Where(c => c.TeamId == teamId && c.CoachId == coachId).FirstOrDefaultAsync();
        }
        public async Task CreateCoachByCoachIdAsync(int teamId, Coach coach)
        {
            var teamToReturn = await GetTeamByTeamIdAsync(teamId, false, false);

            if(teamToReturn != null)
            {
                teamToReturn.Coach.Add(coach);
            }
        }

        public bool UpdateCoachByCoachIdAsync(Coach coach)
        {
            var entity = _context.Coaches.Update(coach);

            if(entity == null)
            {
                return false;
            }
            return true;
        }

        public void DeleteCoachByCoachIdAsync(Coach coach)
        {
            _context.Coaches.Remove(coach);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.OrderBy(c => c.FirstName).ToListAsync();
        }

        public async Task<bool> UserForUserIdExists(int userId)
        {
            return await _context.Users.AnyAsync(c => c.UserId == userId); 
        }

        public async Task<User> GetUserByUserIdAsync(int userId)
        {
            return await _context.Users.Where(c => c.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
