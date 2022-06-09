using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballInfo.Infrastructure.Services
{
    public class CoachRepository: ICoachRepository 
    {
        private readonly BasketballInfoContext _context;

        public CoachRepository(BasketballInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        //public async Task<IEnumerable<Coach>> GetAllCoachesForTeamIdAsync(int teamId)
        //{
        //    return await _context.Coaches.Where(c => c.TeamId == teamId).ToListAsync();
        //}

        //public async Task<Coach> GetCoachByTeamIdAndCoachIdAsyn(int teamId, int coachId)
        //{
        //    return await _context.Coaches.Where(c => c.TeamId == teamId && c.CoachId == coachId).FirstOrDefaultAsync();
        //}
        //public async Task CreateCoachByCoachIdAsync(int teamId, Coach coach)
        //{
        //    var teamToReturn = await GetTeamByTeamIdAsync(teamId, false, false);

        //    if (teamToReturn != null)
        //    {
        //        teamToReturn.Coach.Add(coach);
        //    }
        //}

        //public bool UpdateCoachByCoachIdAsync(Coach coach)
        //{
        //    var entity = _context.Coaches.Update(coach);

        //    if (entity == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public void DeleteCoachByCoachIdAsync(Coach coach)
        //{
        //    _context.Coaches.Remove(coach);
        //}
    }
}
