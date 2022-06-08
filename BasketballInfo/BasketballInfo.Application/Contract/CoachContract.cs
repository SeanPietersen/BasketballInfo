﻿using AutoMapper;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public class CoachContract : ICoachContract
    {
        private readonly IBasketballInfoRepository _basketballInfoRepository;
        private readonly IMapper _mapper;

        public CoachContract(IBasketballInfoRepository basketballInfoRepository, IMapper mapper)
        {
            _basketballInfoRepository = basketballInfoRepository;
            _mapper = mapper;
        }
        public IEnumerable<CoachDto> GetAllCoachesForTeamId(int teamId)
        {
            if (!(_basketballInfoRepository.TeamForTeamIdExists(teamId).Result))
            {
                return null;
            }

            var coaches = _basketballInfoRepository.GetAllCoachesForTeamIdAsync(teamId).Result;

            if (coaches == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<CoachDto>>(coaches);
        }

        public CoachDto GetCoachByTeamIdAndCoachId(int teamId, int coachId)
        {
            if (!(_basketballInfoRepository.TeamForTeamIdExists(teamId).Result))
            {
                return null;
            }

            var coach = _basketballInfoRepository.GetCoachByTeamIdAndCoachIdAsyn(teamId, coachId).Result;

            if (coach == null)
            {
                return null;
            }

            return _mapper.Map<CoachDto>(coach);
        }

        public async Task<CoachDto> CreateCoachByCoachId(int teamId, CoachForCreationDto coachDto)
        {
            if (!(_basketballInfoRepository.TeamForTeamIdExists(teamId).Result))
            {
                return null;
            }

            var finalCoach = _mapper.Map<Coach>(coachDto);

            await _basketballInfoRepository.CreateCoachByCoachIdAsync(teamId, finalCoach);

            await _basketballInfoRepository.SaveChangesAsync();

            return _mapper.Map<CoachDto>(finalCoach);
        }

        public async Task<CoachDto> UpdateCoachByCoachId(int teamId, int coachId, CoachForUpdateDto coachDto)
        {
            if (!(_basketballInfoRepository.TeamForTeamIdExists(teamId)).Result)
            {
                return null;
            }

            var coachEntity = _basketballInfoRepository.GetCoachByTeamIdAndCoachIdAsyn(teamId, coachId).Result;

            if (coachEntity == null)
            {
                return null;
            }


            var coachToReturn = _mapper.Map(coachDto, coachEntity);

            var updateCoachStatus = _basketballInfoRepository.UpdateCoachByCoachIdAsync(coachToReturn);

            if (updateCoachStatus)
            {
                await _basketballInfoRepository.SaveChangesAsync();
            }

            var result = new CoachDto();

            return _mapper.Map(coachToReturn, result);
        }

        public async Task<CoachDto> DeleteCoachByCoachId(int teamId, int coachId)
        {
            if (!_basketballInfoRepository.TeamForTeamIdExists(teamId).Result)
            {
                return null;
            }

            var coachEntity = _basketballInfoRepository.GetCoachByTeamIdAndCoachIdAsyn(teamId, coachId).Result;

            if (coachEntity == null)
            {
                return null;
            }

            _basketballInfoRepository.DeleteCoachByCoachIdAsync(coachEntity);

            await _basketballInfoRepository.SaveChangesAsync();

            var result = new CoachDto();

            return _mapper.Map(coachEntity, result);
        }
    }
}
