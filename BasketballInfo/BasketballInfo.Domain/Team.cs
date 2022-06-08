using System.Collections.Generic;

namespace BasketballInfo.Domain
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public ICollection<Player> Player { get; set; } = new List<Player>();
        public ICollection<Coach> Coach { get; set; } = new List<Coach>();
    }
}
