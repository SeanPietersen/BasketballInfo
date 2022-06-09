using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.DbContexts;
using System;
using System.Threading.Tasks;

namespace BasketballInfo.Infrastructure.Services.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly BasketballInfoContext _context;

        public TeamRepository(BasketballInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Team> GetTeamById(int teamId)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        //{
        //    return await _context.Teams.OrderBy(c => c.Name).ToListAsync();

        //}

        //public async Task<Team> GetTeamByTeamIdAsync(int teamId, bool includePlayers = false, bool includeCoaches = false)
        //{
        //    if (includeCoaches && includeCoaches)
        //    {
        //        return await _context.Teams.Include(c => c.Coaches).Include(d => d.Players)
        //            .Where(c => c.TeamId == teamId).FirstOrDefaultAsync();
        //    }

        //    if (includePlayers)
        //    {
        //        return await _context.Teams.Include(c => c.Players)
        //            .Where(c => c.TeamId == teamId).FirstOrDefaultAsync();
        //    }

        //    if (includeCoaches)
        //    {
        //        return await _context.Teams.Include(c => c.Coaches)
        //            .Where(c => c.TeamId == teamId).FirstOrDefaultAsync();
        //    }
        //    return await _context.Teams.Where(c => c.TeamId == teamId).FirstOrDefaultAsync();
        //}
    }
}
