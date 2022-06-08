using System;

namespace BasketballInfo.Application.Dto
{
    public class PlayerForUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double PlayerHeight { get; set; }
        public double PlayerWeight { get; set; }
    }
}
