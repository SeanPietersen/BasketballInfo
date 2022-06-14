using BasketballInfo.Application.Contract;
using BasketballInfo.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballInfo.API.Controllers
{
    [Route("api/team/{teamId}/coach")]
    [Authorize]
    [ApiController]
    public class CoachController : Controller
    {
        //private readonly ICoachContract _coach;

        //public CoachController(ICoachContract coach)
        //{
        //    _coach = coach;
        //}

        //[HttpGet]
        //public ActionResult<CoachDto> GetAllCoachesForTeamId(int teamId)
        //{
        //    var coaches = _coach.GetAllCoachesForTeamId(teamId);

        //    if(coaches == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(coaches);
        //}

        //[HttpGet("{coachId}")]
        //public ActionResult<CoachDto> GetCoachByCoachIdForTeamId(int teamId, int coachId)
        //{
        //    var coach = _coach.GetCoachByTeamIdAndCoachId(teamId, coachId);

        //    if(coach == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(coach);
        //}

        //[HttpPost]
        //public ActionResult<CoachDto> CreateCoachForTeamId(int teamId, CoachForCreationDto coachDto)
        //{
        //    var coach = _coach.CreateCoachByCoachId(teamId, coachDto);
            
        //    if(coach == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(coach);
        //}

        //[HttpPut("{coachId}")]
        //public ActionResult<CoachDto> UpdateCoachByCoachIdForTeamId(int teamId, int coachId, CoachForUpdateDto coachDto)
        //{
        //    var coachToUpdate = _coach.UpdateCoachByCoachId(teamId, coachId, coachDto);
            
        //    if(coachToUpdate == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(coachToUpdate);
        //}

        //[HttpDelete("{coachId}")]
        //public ActionResult<CoachDto> DeleteCoachByCoachIdForTeamId(int teamId, int coachId)
        //{
        //    var coachToDelete = _coach.DeleteCoachByCoachId(teamId, coachId);

        //    if(coachToDelete == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(coachToDelete);
        //}
    }
}
