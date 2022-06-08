using BasketballInfo.Domain.Enums;

namespace BasketballInfo.Domain
{
    public class Coach
    {
        public int CoachId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsQualified { get; set; }
        public RankType Rank { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }
    }
}

