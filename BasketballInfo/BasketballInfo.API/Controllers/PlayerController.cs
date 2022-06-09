using BasketballInfo.Application.Contract;
using BasketballInfo.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballInfo.API.Controllers
{
    //[Route("api/team/{teamId}/player")]
    //[ApiController]
    //public class PlayerController : Controller
    //{
    //    private readonly IPlayerContract _player;

    //    public PlayerController(IPlayerContract player)
    //    {
    //        _player = player;
    //    }

    //    [HttpGet]
    //    public ActionResult <IEnumerable<PlayerDto>> GetAllPlayersByTeamId(int teamId)
    //    {
    //        var players = _player.GetAllPlayersByTeamIdAsync(teamId);

    //        if(players == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(players);
    //    }

    //    [HttpGet("{playerId}")]
    //    public ActionResult <PlayerDto> GetPlayerByPlayerIdForATeamId(int teamId, int playerId )
    //    {
    //        var player = _player.GetPlayerByPlayerId(teamId, playerId);

    //        if (player == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(player);
    //    }

    //    [HttpPost]
    //    public ActionResult <PlayerDto> CreatePlayerByPlayerIdForTeamId(int teamId, PlayerForCreationDto playerDto)
    //    {
    //        var playerToCreate = _player.CreatePlayerByPlayerId(teamId, playerDto).Result;

    //        if(playerToCreate == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(playerToCreate);
    //    }

    //    [HttpPut("{playerId}")]
    //    public ActionResult <PlayerDto> UpdatePlayerByPlayerId(int teamId, int playerId, PlayerForUpdateDto playerDto)
    //    {
    //        var playerToUpdate = _player.UpdatePlayerByPlayerId(teamId, playerId, playerDto);

    //        if(playerToUpdate == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(playerToUpdate);
    //    }

    //    [HttpDelete("{playerId}")]
    //    public ActionResult <PlayerDto> DeletePlayerByPlayerIdForTeamId(int teamId, int playerId)
    //    {
    //        var playerToDetele = _player.DeletePlayerByPlayerId(teamId, playerId);

    //        if(playerToDetele == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(playerToDetele);
    //    }

    //}
}
