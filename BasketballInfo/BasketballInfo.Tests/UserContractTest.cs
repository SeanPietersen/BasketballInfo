using BasketballInfo.Application.Contract;
using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.Services;
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
        private readonly IUserContract _sut;
        private readonly IBasketballInfoRepository _basketballInfoRepository;
        public UserContractTest()
        {
            _basketballInfoRepository = Substitute.For<IBasketballInfoRepository>();
            _sut = new UserContract(_basketballInfoRepository, _mapper);
        }

        [Fact]
        public async Task GetAllUsers_IsSuccessful()
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
                },
                  new User()
                {
                    UserId =31,
                    FirstName = "Rumer",
                    LastName = "Manis",
                    Email = "rumerkerm@gmail.com",
                    Password = "Rumer1234"
                },

            };

            _basketballInfoRepository.GetAllUsersAsync().Returns(userInDb);

            //Act
            var actual = await _sut.GetAllUsers();

            //Assert
            Assert.Equal(userInDb.Count, actual.ToList().Count);
        }

        [Fact]
        public async Task GetUserByUserById_ShouldReturnNull_InvalidUserId()
        {
            //Arrange
            var userId = 0;

            _basketballInfoRepository.GetUserByUserIdAsync(userId).ReturnsNull();

            //Act
            var actual = await _sut.GetUserByUserId(userId);

            //Assert
            Assert.Null(actual);

        }

        [Fact]
        public async Task GetUserByUserId_IsSuccessful()
        {
            //Arrange
            var userId = 1;

            var userInDb = new User()
            {
                UserId = 1,
                FirstName = "Sean",
                LastName = "Pietersen",
                Email = "seanpietersen7@gmail.com",
                Password = "Sean2563"
            };

            _basketballInfoRepository.GetUserByUserIdAsync(userId).Returns(userInDb);

            //Act
            var actual = await _sut.GetUserByUserId(userId);

            //Assert
            Assert.Equal(userInDb.FirstName, actual.FirstName);
            Assert.Equal(userInDb.Email, actual.Email);
            Assert.Equal(userInDb.Password, actual.Password);
        }
    }
}
