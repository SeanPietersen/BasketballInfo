﻿using BasketballInfo.Application.Contract;
using BasketballInfo.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballInfo.API.Controllers
{
    [Route("api/teams/{teamId}/player")]
    [Authorize]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerContract _playerContract;

        public PlayerController(IPlayerContract playerContract)
        {
            _playerContract = playerContract;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlayerDto>> GetAllPlayersForTeamId(int teamId)
        {
            var players = _playerContract.GetAllPlayersForTeam(teamId);

            if (players == null)
            {
                return NotFound();
            }
            return Ok(players);
        }

        [HttpGet("{playerId}")]
        public ActionResult<PlayerDto> GetPlayerForTeamId(int teamId, int playerId)
        {
            var player = _playerContract.GetPlayerById(teamId, playerId);

            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        //[HttpPost]
        //public ActionResult<PlayerDto> CreatePlayerForTeamId(int teamId, CreatePlayerDto playerDto)
        //{
        //    var playerToCreate = _playerContract.CreatePlayerByPlayerId(teamId, playerDto).Result;

        //    if (playerToCreate == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(playerToCreate);
        //}

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

    }
}
