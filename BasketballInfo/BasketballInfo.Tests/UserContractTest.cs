using BasketballInfo.Application.Contract;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.Services;
using BasketballInfo.Infrastructure.Services.Repositories;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BasketballInfo.Tests
{
    public class UserContractTest: ContextTest
    {
        private readonly IUserContract userContract;
        private readonly IUserRepository _userRepository;
        public UserContractTest()
        {
            _userRepository = Substitute.For<IUserRepository>();
            userContract = new UserContract(_userRepository, _mapper);
        }

        [Fact]
        public void RegisterUser_ShouldReturnNull_UserAlreadyExists()
        {
            //Arrange

            var userInDb = new User()
            {
                UserId = 1,
                FirstName = "Sean",
                LastName = "Pietersen",
                Email = "seanpietersen7@gmail.com",
                Password = "Sean2563"
            };


            var createdUser = new RegisterUserDto()
            {
                FirstName = "Percy",
                LastName = "Pietersen",
                Email = "seanpietersen7@gmail.com",
                Password = "Sean2563"
            };

            _userRepository.GetUserByEmailAsync(createdUser.Email).Returns(userInDb);

            //Act
            var actual = userContract.RegisterUser(createdUser);

            //Assert
            Assert.Null(actual);
        }

        [Fact]
        public void RegisterUser_Successful()
        {
            //Arrange
            var userInDb = new List<User>()
            {
                new User()
                {
                    UserId = 1,
                    FirstName = "Sean",
                    LastName = "Pietersen",
                    Email = "seanpietersen7@gmail.com",
                    Password = "Sean2563"
                },
                 new User()
                {
                    UserId = 2,
                    FirstName = "Jason",
                    LastName = "Pietersen",
                    Email = "jase.pietersen7@gmail.com",
                    Password = "Jason2563"
                }
             };


            var createdUserDto = new RegisterUserDto()
            {
                FirstName = "Percy",
                LastName = "Pietersen",
                Email = "pfpietersen@gmail.com",
                Password = "Sean2563"
            };

            var createdUser = new User()
            {
                FirstName = "Percy",
                LastName = "Pietersen",
                Email = "pfpietersen@gmail.com",
                Password = "Sean2563"
            };

            _userRepository.GetUserByEmailAsync(createdUserDto.Email).ReturnsNull();
            _userRepository.RegisterUserAsync(createdUser).Returns(createdUser);

            //Act
            var actual = userContract.RegisterUser(createdUserDto);

            //Assert
            Assert.Equal(createdUser.FirstName, actual.FirstName);
        }

        //[Fact]
        //public async Task GetAllUsers_IsSuccessful()
        //{
        //    //Arrange
        //    var userInDb = new List<User>()
        //    {
        //        new User()
        //        {
        //            UserId = 1,
        //            FirstName = "Sean",
        //            LastName = "Pietersen",
        //            Email = "seanpietersen7@gmail.com",
        //            Password = "Sean2563"
        //        },
        //         new User()
        //        {
        //            UserId = 2,
        //            FirstName = "Jason",
        //            LastName = "Pietersen",
        //            Email = "jase.pietersen7@gmail.com",
        //            Password = "Jason2563"
        //        },
        //          new User()
        //        {
        //            UserId =31,
        //            FirstName = "Rumer",
        //            LastName = "Manis",
        //            Email = "rumerkerm@gmail.com",
        //            Password = "Rumer1234"
        //        },

        //    };

        //    _basketballInfoRepository.GetAllUsersAsync().Returns(userInDb);

        //    //Act
        //    var actual = await _sut.GetAllUsers();

        //    //Assert
        //    Assert.Equal(userInDb.Count, actual.ToList().Count);
        //}

        //[Fact]
        //public async Task GetUserByUserById_ShouldReturnNull_InvalidUserId()
        //{
        //    //Arrange
        //    var userId = 0;

        //    _basketballInfoRepository.GetUserByUserIdAsync(userId).ReturnsNull();

        //    //Act
        //    var actual = await _sut.GetUserByUserId(userId);

        //    //Assert
        //    Assert.Null(actual);

        //}

        //[Fact]
        //public async Task GetUserByUserId_IsSuccessful()
        //{
        //    //Arrange
        //    var userId = 1;

        //    var userInDb = new User()
        //    {
        //        UserId = 1,
        //        FirstName = "Sean",
        //        LastName = "Pietersen",
        //        Email = "seanpietersen7@gmail.com",
        //        Password = "Sean2563"
        //    };

        //    _basketballInfoRepository.GetUserByUserIdAsync(userId).Returns(userInDb);

        //    //Act
        //    var actual = await _sut.GetUserByUserId(userId);

        //    //Assert
        //    Assert.Equal(userInDb.FirstName, actual.FirstName);
        //    Assert.Equal(userInDb.Email, actual.Email);
        //    Assert.Equal(userInDb.Password, actual.Password);
        //}
    }
}
