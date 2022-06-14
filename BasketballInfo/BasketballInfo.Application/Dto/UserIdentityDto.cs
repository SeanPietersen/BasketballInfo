using BasketballInfo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Dto
{
    public class UserIdentityDto
    {
        public UserDto User { get; set; }
        public string IdentityToken { get; set; }
    }
}
