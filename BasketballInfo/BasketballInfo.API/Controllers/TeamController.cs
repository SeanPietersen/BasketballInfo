using BasketballInfo.Application.Contract;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballInfo.API.Controllers
{
    [ApiController]

    [Route("api/teams")]
    public class TeamController : Controller
    {

        private readonly ITeamContract _teamContract;

        public TeamController(ITeamContract teamContract)
        {
            _teamContract = teamContract;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamDto>> GetAllTeams()
        {

            var teams = _teamContract.GetAllTeams().Result;

            return Ok(teams);
        }

        [HttpGet("{id}")]

        public ActionResult<TeamDto> GetTeamByTeamId(int teamId, bool includePlayers, bool includeCoaches)
        {
            var team = _teamContract.GetTeamByTeamId(teamId, includePlayers, includeCoaches).Result;

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }
    }
}
