using AutoMapper;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.Services;
using BasketballInfo.Infrastructure.Services.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public class PlayerContract : IPlayerContract
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly Infrastructure.Services.Repositories.ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public PlayerContract(IPlayerRepository playerRepository, Infrastructure.Services.Repositories.ITeamRepository teamRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public IEnumerable<PlayerDto> GetAllPlayersForTeam(int teamId)
        {
            var team = _teamRepository.GetTeamByIdAsync(teamId, true, false).Result;

            if (team == null)
            {
                return null;
            }

            var players = team.Players;

            return (_mapper.Map<IEnumerable<PlayerDto>>(players));
        }

        public PlayerDto GetPlayerById(int teamId, int playerId)
        {
            var team = _teamRepository.GetTeamByIdAsync(teamId, true, false).Result;

            if (team == null)
            {
                return null;
            }

            var player = _playerRepository.GetPlayerByIdAsync(teamId, playerId).Result;

            if (player == null)
            {
                return null;
            }

            return _mapper.Map<PlayerDto>(player);
        }

        //public async Task<PlayerDto> CreatePlayerById(int teamId, CreatePlayerDto playerDto)
        //{
        //    var team = _teamRepository.GetTeamByIdAsync(teamId, true, false).Result;

        //    if (team == null)
        //    {
        //        return null;
        //    }

        //    var createdPlayer = new Player()
        //    {
        //        FirstName = playerDto.FirstName,
        //        LastName = playerDto.LastName,
        //        DateOfBirth = playerDto.DateOfBirth,
        //        PlayerHeight = playerDto.PlayerHeight,
        //        PlayerWeight = playerDto.PlayerWeight
        //    };

        //    await _playerRepository.CreatePlayerByPlayerIdAsync(teamId, finalPlayer);

        //    await _teamRepository.SaveChangesAsync();

        //    return _mapper.Map<PlayerDto>(finalPlayer);

        //}

        //public async Task<PlayerDto> UpdatePlayerByPlayerId(int teamId, int playerId, PlayerForUpdateDto playerDto)
        //{
        //    if (!(_teamRepository.TeamForTeamIdExists(teamId)).Result)
        //    {
        //        return null;
        //    }

        //    var playerEntity = _teamRepository.GetPlayerByPlayerIdAsync(teamId, playerId).Result;

        //    if (playerEntity == null)
        //    {
        //        return null;
        //    }


        //    var playerToReturn = _mapper.Map(playerDto, playerEntity);

        //    var updatePlayerStatus = _teamRepository.UpdatePlayerByPlayerIdAsync(playerToReturn);

        //    if (updatePlayerStatus)
        //    {
        //        await _teamRepository.SaveChangesAsync();
        //    }

        //    var result = new PlayerDto();

        //    return _mapper.Map(playerToReturn, result);
        //}

        //public async Task<PlayerDto> DeletePlayerByPlayerId(int teamId, int playerId)
        //{
        //    if (!_teamRepository.TeamForTeamIdExists(teamId).Result)
        //    {
        //        return null;
        //    }

        //    var playerEntity = _teamRepository.GetPlayerByPlayerIdAsync(teamId, playerId).Result;

        //    if (playerEntity == null)
        //    {
        //        return null;
        //    }

        //    _teamRepository.DeletePlayerByPlayerIdAsync(playerEntity);

        //    await _teamRepository.SaveChangesAsync();

        //    var result = new PlayerDto();

        //    return _mapper.Map(playerEntity, result);
        //}
    }
}
