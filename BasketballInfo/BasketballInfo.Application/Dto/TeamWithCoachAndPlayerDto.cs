using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Dto
{
    public class TeamWithCoachAndPlayerDto: TeamDto
    {
        public int NumberOfPlayers
        {
            get
            {
                return Player.Count;
            }
        }

        public ICollection<PlayerDto> Player { get; set; } = new List<PlayerDto>();
        public int NumberOfCoaches
        {
            get
            {
                return Coach.Count;
            }
        }
        public ICollection<CoachDto> Coach { get; set; } = new List<CoachDto>();
    }
}
