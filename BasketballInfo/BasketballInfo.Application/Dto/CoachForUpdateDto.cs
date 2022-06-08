using BasketballInfo.Domain.Enums;

namespace BasketballInfo.Application.Dto
{
    public class CoachForUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsQualified { get; set; }
        public RankType Rank { get; set; }
    }
}
