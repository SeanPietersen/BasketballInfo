using AutoMapper;
using BasketballInfo.Application.Authentication;
using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public class AuthenticationContract : IAuthenticationContract
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public AuthenticationContract(IConfiguration configuration, IUserRepository userRepsitory)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _userRepository = userRepsitory;
        }

        public async Task<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
           
        }

        private async Task<User> ValidateUserCredentials(string email, string password)
        {
            //check if email exists
            var userEmailCheck = await _userRepository.GetUserByEmailAsync(email);

            if (userEmailCheck == null)
            {
                // email/username doesnt exists
                return null;
            }

            //check if password matches email
            if (userEmailCheck.Password != password)
            {
                return null;
            }

            var user = new User()
            {
                UserId = userEmailCheck.UserId,
                FirstName = userEmailCheck.FirstName,
                LastName = userEmailCheck.LastName,
            };
            //successful signup returns user
            return user;

        }
    }
}
