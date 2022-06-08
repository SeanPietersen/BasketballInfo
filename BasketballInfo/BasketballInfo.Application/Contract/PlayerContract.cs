using AutoMapper;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public class PlayerContract : IPlayerContract
    {
        private readonly IBasketballInfoRepository _basketballInfoRepository;
        private readonly IMapper _mapper;

        public PlayerContract(IBasketballInfoRepository basketballInfoRepository, IMapper mapper)
        {
            _basketballInfoRepository = basketballInfoRepository;
            _mapper = mapper;
        }

        public IEnumerable<PlayerDto> GetAllPlayersByTeamId(int teamId)
        {
            if (!(_basketballInfoRepository.TeamForTeamIdExists(teamId)).Result)
            {
                return null;
            }

            var allPlayers = _basketballInfoRepository.GetAllPlayersByTeamIdAsync(teamId).Result;

            if (allPlayers == null)
            {
                return null;
            }

            return (_mapper.Map<IEnumerable<PlayerDto>>(allPlayers));
        }

        public PlayerDto GetPlayerByPlayerId(int teamId, int playerId)
        {
            if (!(_basketballInfoRepository.TeamForTeamIdExists(teamId)).Result)
            {
                return null;
            }

            var player = _basketballInfoRepository.GetPlayerByPlayerIdAsync(teamId, playerId).Result;

            if (player == null)
            {
                return null;
            }

            return _mapper.Map<PlayerDto>(player);
        }

        public async Task<PlayerDto> CreatePlayerByPlayerId(int teamId, PlayerForCreationDto playerDto)
        {
            if (!(_basketballInfoRepository.TeamForTeamIdExists(teamId)).Result)
            {
                return null;
            }

            var finalPlayer = _mapper.Map<Player>(playerDto);

            await _basketballInfoRepository.CreatePlayerByPlayerIdAsync(teamId, finalPlayer);

            await _basketballInfoRepository.SaveChangesAsync();

            return _mapper.Map<PlayerDto>(finalPlayer);

        }

        public async Task<PlayerDto> UpdatePlayerByPlayerId(int teamId, int playerId, PlayerForUpdateDto playerDto)
        {
            if (!(_basketballInfoRepository.TeamForTeamIdExists(teamId)).Result)
            {
                return null;
            }

            var playerEntity = _basketballInfoRepository.GetPlayerByPlayerIdAsync(teamId, playerId).Result;

            if (playerEntity == null)
            {
                return null;
            }


            var playerToReturn = _mapper.Map(playerDto, playerEntity);

            var updatePlayerStatus = _basketballInfoRepository.UpdatePlayerByPlayerIdAsync(playerToReturn);

            if (updatePlayerStatus)
            {
                await _basketballInfoRepository.SaveChangesAsync();
            }

            var result = new PlayerDto();

            return _mapper.Map(playerToReturn, result);
        }

        public async Task<PlayerDto> DeletePlayerByPlayerId(int teamId, int playerId)
        {
            if (!_basketballInfoRepository.TeamForTeamIdExists(teamId).Result)
            {
                return null;
            }

            var playerEntity = _basketballInfoRepository.GetPlayerByPlayerIdAsync(teamId, playerId).Result;

            if (playerEntity == null)
            {
                return null;
            }

            _basketballInfoRepository.DeletePlayerByPlayerIdAsync(playerEntity);

            await _basketballInfoRepository.SaveChangesAsync();

            var result = new PlayerDto();

            return _mapper.Map(playerEntity, result);
        }
    }
}
