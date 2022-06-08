using System.Collections.Generic;

namespace BasketballInfo.Application.Dto
{
    public class TeamWithPlayersDto : TeamDto
    {
        public int NumberOfPlayers
        {
            get
            {
                return Player.Count;
            }
        }

        public ICollection<PlayerDto> Player { get; set; } = new List<PlayerDto>();

    }
}



