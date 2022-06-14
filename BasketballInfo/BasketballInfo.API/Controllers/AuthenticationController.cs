﻿using BasketballInfo.Application.Authentication;
using BasketballInfo.Application.Contract;
using Microsoft.AspNetCore.Mvc;

namespace BasketballInfo.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationContract _authenticationContract;

        public AuthenticationController(IAuthenticationContract authenticationContract)
        {
            _authenticationContract = authenticationContract;
        }


        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            //Step 1: Validate the username/ password
            var user = _authenticationContract.Authenticate(authenticationRequestBody);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }

    }
}