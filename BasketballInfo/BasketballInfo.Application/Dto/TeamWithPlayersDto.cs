using System.Collections.Generic;

namespace BasketballInfo.Application.Dto
{
    public class TeamWithPlayersDto : TeamDto
    {
        public int NumberOfPlayers
        {
            get
            {
                return Players.Count;
            }
        }

        public ICollection<PlayerDto> Players { get; set; } = new List<PlayerDto>();

    }
}



