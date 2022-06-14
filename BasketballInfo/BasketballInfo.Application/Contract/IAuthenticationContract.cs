using BasketballInfo.Application.Authentication;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public interface IAuthenticationContract
    {
        Task<string> Authenticate(AuthenticationRequestBody authenticationRequestBody);
    }
}
