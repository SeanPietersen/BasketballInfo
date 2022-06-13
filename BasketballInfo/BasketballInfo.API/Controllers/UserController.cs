﻿using BasketballInfo.Application.Contract;
using BasketballInfo.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BasketballInfo.API.Controllers
{
    [ApiController]

    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserContract _userContract;

        public UserController(IUserContract userContract)
        {
            _userContract = userContract;
        }

        [HttpPost("register")]
        public ActionResult<UserDto> RegisterUser([FromBody] RegisterUserDto userDto)
        {
            var user = _userContract.RegisterUser(userDto).Result;

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("signin")]
        public ActionResult<UserDto> UserSignIn([FromBody] UserSignUpDto userDto)
        {
            var user = _userContract.UserSignUp(userDto).Result;

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {

            var user = _userContract.GetAllUsers().Result;

            return Ok(user);
        }

        [HttpGet("{userId}")]
        public ActionResult<UserDto> GetUserById(int userId)
        {
            var user = _userContract.GetUserById(userId).Result;

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
