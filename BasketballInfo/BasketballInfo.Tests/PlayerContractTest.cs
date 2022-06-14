using BasketballInfo.Application.Contract;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.Services.Repositories;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BasketballInfo.Tests
{
    public class PlayerContractTest: ContextTest
    {
        private readonly IPlayerContract _playerContract;
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerRepository _playerRepository;

        public PlayerContractTest()
        {
            _teamRepository = Substitute.For<ITeamRepository>();
            _playerRepository = Substitute.For<IPlayerRepository>();
            _playerContract = new PlayerContract(_playerRepository, _teamRepository, _mapper);
        }

        [Fact]
        public void GetAllPlayersForTeam_ShouldReturnNull_InvalidTeamId()
        {
            //Arrange
            var teamId = 0;

            _teamRepository.GetTeamByIdAsync(teamId).ReturnsNull();

            //Act
            IEnumerable<PlayerDto> actual = _playerContract.GetAllPlayersForTeam(teamId);

            //Assert
            Assert.Null(actual);
        }

        [Fact]
        public void GetAllPlayersForTeamId_IsSuccessful()
        {
            //Arrange
            var teamId = 1;

            var teamInDb = new Team()
            {
                TeamId = 1,
                Name = "MOCK Test 1",
                State = "MOCK Test 1 State",
                Players = new List<Player>()
                {
                    new Player()
                    {
                        PlayerId = 1,
                        FirstName = "Sean",
                        LastName = "Pietersen",
                        DateOfBirth = new DateTime(1997,01,14),
                        PlayerHeight = 1.76,
                        PlayerWeight = 82
                    },
                    new Player()
                    {
                        PlayerId = 2,
                        FirstName = "Jason",
                        LastName = "Pietersen",
                        DateOfBirth = new DateTime(1994,04,08),
                        PlayerHeight = 1.78,
                        PlayerWeight = 90
                    }
                }
            };

            _teamRepository.GetTeamByIdAsync(teamId).Returns(teamInDb);


            //Act
            IEnumerable<PlayerDto> actual = _playerContract.GetAllPlayersForTeam(teamId);

            //Assert
            Assert.Equal(teamInDb.Players.Count, actual.ToList().Count);

        }

        [Fact]
        public void GetPlayerByPlayerIdAndTeamId_ShouldReturnNull_InvalidTeamId()
        {
            //Arrange
            var teamId = 0;
            var playerId = 1;

            _teamRepository.GetTeamByIdAsync(teamId).ReturnsNull();

            _playerRepository.GetPlayerByIdAsync(teamId, playerId).ReturnsNull();


            //Act
            var actual = _playerContract.GetPlayerById(teamId, playerId);

            //Assert
            Assert.Null(actual);

        }

        [Fact]
        public void GetPlayerByPlayerIdAndTeamId_ShouldReturnNull_InvalidPlayerId()
        {
            //Arrange
            var teamId = 1;
            var playerId = 0;

            var teamInDb = new Team()
            {
                TeamId = 1,
                Name = "MOCK Test 1",
                State = "MOCK Test 1 State",
                Players = new List<Player>()
                {
                    new Player()
                    {
                        PlayerId = 1,
                        FirstName = "Sean",
                        LastName = "Pietersen",
                        DateOfBirth = new DateTime(1997,01,14),
                        PlayerHeight = 1.76,
                        PlayerWeight = 82
                    },
                    new Player()
                    {
                        PlayerId = 2,
                        FirstName = "Jason",
                        LastName = "Pietersen",
                        DateOfBirth = new DateTime(1994,04,08),
                        PlayerHeight = 1.78,
                        PlayerWeight = 90
                    }
                }
            };

            _teamRepository.GetTeamByIdAsync(teamId, true, false).Returns(teamInDb);

            _playerRepository.GetPlayerByIdAsync(teamId, playerId).ReturnsNull();


            //Act
            var actual = _playerContract.GetPlayerById(teamId, playerId);

            //Assert
            Assert.Null(actual);
        }

        [Fact]
        public void GetPlayerByPlayerIdAndTeamId_IsSuccessful()
        {
            //Arrange
            var teamId = 1;
            var playerId = 1;

            var playerInfo = new Player()
            {
                PlayerId = 1,
                FirstName = "Sean",
                LastName = "Pietersen",
                DateOfBirth = new DateTime(1997, 01, 14),
                PlayerHeight = 1.76,
                PlayerWeight = 82
            };

            var teamInDb = new Team()
            {
                TeamId = 1,
                Name = "MOCK Test 1",
                State = "MOCK Test 1 State",
                Players = new List<Player>()
                {
                    new Player()
                    {
                        PlayerId = 1,
                        FirstName = "Sean",
                        LastName = "Pietersen",
                        DateOfBirth = new DateTime(1997,01,14),
                        PlayerHeight = 1.76,
                        PlayerWeight = 82
                    },
                    new Player()
                    {
                        PlayerId = 2,
                        FirstName = "Jason",
                        LastName = "Pietersen",
                        DateOfBirth = new DateTime(1994,04,08),
                        PlayerHeight = 1.78,
                        PlayerWeight = 90
                    }
                }
            };

            _teamRepository.GetTeamByIdAsync(teamId, true, false).Returns(teamInDb);

            _playerRepository.GetPlayerByIdAsync(teamId, playerId).Returns(playerInfo);


            //Act
            var actual = _playerContract.GetPlayerById(teamId, playerId);

            //Assert
            Assert.Equal(playerInfo.FirstName, actual.FirstName);
            Assert.Equal(playerInfo.LastName, actual.LastName);
        }

        //[Fact]
        //public void CreatePlayerByPlayerId_ShouldReturnNull_InvalidTeamId()
        //{
        //    //Arrange
        //    int teamId = 0;

        //    PlayerForCreationDto playerDto = new PlayerForCreationDto()
        //    {
        //        FirstName = "Rumer",
        //        LastName = "Manis",
        //        DateOfBirth = new DateTime(1996, 12, 17),
        //        PlayerHeight = 1.65,
        //        PlayerWeight = 58
        //    };

        //    _basketballInfoRepository.GetTeamByTeamIdAsync(teamId, true, false).ReturnsNull();

        //    //Act
        //    PlayerDto actual = _sut.CreatePlayerByPlayerId(teamId, playerDto).Result;

        //    //Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void CreatePlayerByPlayerId_IsSuccessful()
        //{
        //    //Arrange
        //    int teamId = 1;

        //    var teamInDbInDb = new Team()
        //    {
        //        TeamId = 1,
        //        Name = "Mock Test 1",
        //        State = "Los Angalese"
        //    };

        //    var playerInDb = new List<Player>()
        //    {
        //        new Player()
        //        {
        //            PlayerId = 1,
        //            FirstName = "Sean",
        //            LastName = "Pietersen",
        //            DateOfBirth = new DateTime(1996, 12, 17),
        //            PlayerHeight = 1.65,
        //            PlayerWeight = 58
        //        },
        //        new Player()
        //        {
        //            PlayerId = 2,
        //            FirstName = "Jason",
        //            LastName = "Pietersen",
        //            DateOfBirth = new DateTime(1996, 12, 17),
        //            PlayerHeight = 1.65,
        //            PlayerWeight = 58
        //        }
        //    };

        //    PlayerForCreationDto playerDto = new PlayerForCreationDto()
        //    {
        //        FirstName = "Rumer",
        //        LastName = "Manis",
        //        DateOfBirth = new DateTime(1996, 12, 17),
        //        PlayerHeight = 1.65,
        //        PlayerWeight = 58
        //    };

        //    Player player = new Player()
        //    {
        //        FirstName = "Rumer",
        //        LastName = "Manis",
        //        DateOfBirth = new DateTime(1996, 12, 17),
        //        PlayerHeight = 1.65,
        //        PlayerWeight = 58
        //    };

        //    _basketballInfoRepository.TeamForTeamIdExists(teamId).Returns(true);

        //    _basketballInfoRepository.CreatePlayerByPlayerIdAsync(teamId, Arg.Any<Player>());

        //    _basketballInfoRepository.SaveChangesAsync().Returns(true);


        //    //Act
        //    PlayerDto actual = _sut.CreatePlayerByPlayerId(teamId, playerDto).Result;

        //    //Assert
        //    Assert.Equal(player.FirstName, actual.FirstName);
        //    Assert.Equal(player.LastName, actual.LastName);
        //    Assert.Equal(player.PlayerWeight, actual.PlayerWeight);
        //}

        //[Fact]
        //public void UpdatePlayerByPlayerId_ShouldReturnNull_InvalidTeamId()
        //{
        //    //Arrange
        //    int teamId = 0;

        //    int playerId = 2;

        //    _basketballInfoRepository.GetTeamByTeamIdAsync(teamId, true, false).ReturnsNull();

        //    //Act
        //    var actual = _sut.UpdatePlayerByPlayerId(teamId, playerId, null).Result;

        //    //Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void UpdatePlayerByPlayerId_ShouldReturnNull_InvalidPlayerId()
        //{
        //    //Arrange

        //    int teamId = 1;

        //    int playerId = 0;

        //    var teamInDbInDb = new Team()
        //    {
        //        TeamId = 1,
        //        Name = "Mock Test 1",
        //        State = "Los Angalese",
        //        Players = new List<Player>()
        //        {
        //            new Player()
        //            {
        //                PlayerId = 1,
        //                FirstName = "Sean",
        //                LastName = "Pietersen",
        //                DateOfBirth = new DateTime(1996, 12, 17),
        //                PlayerHeight = 1.65,
        //                PlayerWeight = 58
        //            },
        //            new Player()
        //            {
        //                PlayerId = 2,
        //                FirstName = "Jason",
        //                LastName = "Pietersen",
        //                DateOfBirth = new DateTime(1996, 12, 17),
        //                PlayerHeight = 1.65,
        //                PlayerWeight = 58
        //            }
        //        }
        //    };

        //    _basketballInfoRepository.TeamForTeamIdExists(teamId).Returns(true);

        //    _basketballInfoRepository.GetPlayerByPlayerIdAsync(teamId, playerId).ReturnsNull();

        //    //Act
        //    var actual = _sut.UpdatePlayerByPlayerId(teamId, playerId, null).Result;

        //    //Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void UpdatePlayerByPlayerId_IsSuccessful()
        //{
        //    //Arrange

        //    int teamId = 1;

        //    int playerId = 0;

        //    var teamInDb = new Team()
        //    {
        //        TeamId = 1,
        //        Name = "Mock Test 1",
        //        State = "Los Angalese",
        //        Players = new List<Player>()
        //        {
        //            new Player()
        //            {
        //                PlayerId = 1,
        //                FirstName = "Sean",
        //                LastName = "Pietersen",
        //                DateOfBirth = new DateTime(1996, 12, 17),
        //                PlayerHeight = 1.65,
        //                PlayerWeight = 58
        //            },
        //            new Player()
        //            {
        //                PlayerId = 2,
        //                FirstName = "Jason",
        //                LastName = "Pietersen",
        //                DateOfBirth = new DateTime(1996, 12, 17),
        //                PlayerHeight = 1.65,
        //                PlayerWeight = 58
        //            }
        //        }
        //    };

        //    var playerInDb = new Player()
        //    {
        //        PlayerId = 1,
        //        FirstName = "Sean",
        //        LastName = "Pietersen",
        //        DateOfBirth = new DateTime(1996, 12, 17),
        //        PlayerHeight = 1.65,
        //        PlayerWeight = 58
        //    };

        //    var playerForUpdateDto = new PlayerForUpdateDto()
        //    {
        //        FirstName = "Updated - Sean",
        //        LastName = "Pietersen",
        //        DateOfBirth = new DateTime(1996, 12, 17),
        //        PlayerHeight = 1.65,
        //        PlayerWeight = 80
        //    };

        //    _basketballInfoRepository.TeamForTeamIdExists(teamId).Returns(true);

        //    _basketballInfoRepository.GetTeamByTeamIdAsync(teamId, true, false).Returns(teamInDb);

        //    _basketballInfoRepository.GetPlayerByPlayerIdAsync(teamId, playerId).Returns(playerInDb);

        //    //Act
        //    var actual = _sut.UpdatePlayerByPlayerId(teamId, playerId, playerForUpdateDto).Result;

        //    //Assert
        //    Assert.Equal(playerForUpdateDto.FirstName, actual.FirstName);
        //    Assert.Equal(playerForUpdateDto.PlayerWeight, actual.PlayerWeight);
        //}

        //[Fact]
        //public void DeletePlayerByPlayerId_ShouldReturnNull_InvalidTeam()
        //{
        //    //Arrange
        //    var teamId = 0;

        //    int playerId = 1;

        //    _basketballInfoRepository.GetTeamByTeamIdAsync(teamId, true, false).ReturnsNull();

        //    //Act
        //    var actual = _sut.DeletePlayerByPlayerId(teamId, playerId).Result;

        //    //Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void DeletePlayerByPlayerId_ShouldReturnNull_InvalidPlayerId()
        //{
        //    //Arrange

        //    int teamId = 1;

        //    int playerId = 0;


        //    var teamInDb = new Team()
        //    {
        //        TeamId = 1,
        //        Name = "Mock Test 1",
        //        State = "Los Angalese",
        //        Players = new List<Player>()
        //        {
        //            new Player()
        //            {
        //                PlayerId = 1,
        //                FirstName = "Sean",
        //                LastName = "Pietersen",
        //                DateOfBirth = new DateTime(1996, 12, 17),
        //                PlayerHeight = 1.65,
        //                PlayerWeight = 58
        //            },
        //            new Player()
        //            {
        //                PlayerId = 2,
        //                FirstName = "Jason",
        //                LastName = "Pietersen",
        //                DateOfBirth = new DateTime(1996, 12, 17),
        //                PlayerHeight = 1.65,
        //                PlayerWeight = 58
        //            }
        //        }
        //    };

        //    _basketballInfoRepository.GetTeamByTeamIdAsync(teamId, true, false).Returns(teamInDb);

        //    _basketballInfoRepository.GetPlayerByPlayerIdAsync(teamId, playerId).ReturnsNull();

        //    //Act
        //    var actual = _sut.DeletePlayerByPlayerId(teamId, playerId).Result;

        //    //Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void DeleteNinjaById_IsSuccessful()
        //{
        //    //Arrange

        //    int teamId = 1;

        //    int playerId = 1;

        //    var playerInDb = new Player()
        //    {
        //        PlayerId = 1,
        //        FirstName = "Sean",
        //        LastName = "Pietersen",
        //        DateOfBirth = new DateTime(1996, 12, 17),
        //        PlayerHeight = 1.65,
        //        PlayerWeight = 58
        //    };

        //    var teamInDb = new Team()
        //    {
        //        TeamId = 1,
        //        Name = "Mock Test 1",
        //        State = "Los Angalese",
        //        Players = new List<Player>()
        //        {
        //            new Player()
        //            {
        //                PlayerId = 1,
        //                FirstName = "Sean",
        //                LastName = "Pietersen",
        //                DateOfBirth = new DateTime(1996, 12, 17),
        //                PlayerHeight = 1.65,
        //                PlayerWeight = 58
        //            },
        //            new Player()
        //            {
        //                PlayerId = 2,
        //                FirstName = "Jason",
        //                LastName = "Pietersen",
        //                DateOfBirth = new DateTime(1996, 12, 17),
        //                PlayerHeight = 1.65,
        //                PlayerWeight = 58
        //            }
        //        }
        //    };

        //    _basketballInfoRepository.TeamForTeamIdExists(teamId).Returns(true);

        //    _basketballInfoRepository.GetPlayerByPlayerIdAsync(teamId, playerId).Returns(playerInDb);

        //    _basketballInfoRepository.SaveChangesAsync().Returns(true);

        //    //Act
        //    var actual = _sut.DeletePlayerByPlayerId(teamId, playerId).Result;

        //    //Assert
        //    Assert.Equal(playerInDb.FirstName, actual.FirstName);
        //    Assert.Equal(playerInDb.DateOfBirth, actual.DateOfBirth);
        //}
    }
}
