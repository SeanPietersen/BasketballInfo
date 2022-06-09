using BasketballInfo.Application.Contract;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;
using BasketballInfo.Domain.Enums;
using BasketballInfo.Infrastructure.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BasketballInfo.Tests
{
    public class CoachContractTest : ContextTest
    {
        //private readonly ICoachContract _sut;
        //private readonly IBasketballInfoRepository _basketballInfoRepository;

        //public CoachContractTest()
        //{
        //    _basketballInfoRepository = Substitute.For<IBasketballInfoRepository>();
        //    _sut = new CoachContract(_basketballInfoRepository, _mapper);
        //}

        //[Fact]
        //public void GetAllCoachesForTeamId_ShouldReturnNull_InvalidTeamId()
        //{
        //    //Arrange
        //    var teamId = 0;

        //    _basketballInfoRepository.GetAllCoachesForTeamIdAsync(teamId).ReturnsNull();

        //    //Act
        //    IEnumerable<CoachDto> actual = _sut.GetAllCoachesForTeamId(teamId);

        //    //Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void GetAllCoachesForTeamId_IsSuccessful()
        //{
        //    //Arrange
        //    var teamId = 1;

        //    var listOfCoaches = new List<Coach>()
        //    {
        //        new Coach()
        //        {
        //            CoachId = 1,
        //            FirstName = "Sean",
        //            LastName = "Pietersen",
        //            YearsOfExperience = 1,
        //            IsQualified = false,
        //            Rank = RankType.Head_Coach
        //        },
        //        new Coach()
        //        {
        //            CoachId = 2,
        //            FirstName = "Jason",
        //            LastName = "Pietersen",
        //            YearsOfExperience = 15,
        //            IsQualified = true,
        //            Rank = RankType.Head_Coach
        //        }
        //    };

        //    _basketballInfoRepository.TeamForTeamIdExists(teamId).Returns(true);

        //    _basketballInfoRepository.GetAllCoachesForTeamIdAsync(teamId).Returns(listOfCoaches);


        //    //Act
        //    IEnumerable<CoachDto> actual = _sut.GetAllCoachesForTeamId(teamId);

        //    //Assert
        //    Assert.Equal(listOfCoaches.Count, actual.ToList().Count);

        //}

        //[Fact]
        //public void GetCoachByCoachIdAndTeamId_ShouldReturnNull_InvalidTeamId()
        //{
        //    //Arrange
        //    var teamId = 0;
        //    var coachId = 1;

        //    var coachInfo = new Coach()
        //    {
        //        CoachId = 1,
        //        FirstName = "Sean",
        //        LastName = "Pietersen",
        //        YearsOfExperience = 1,
        //        IsQualified = false,
        //        Rank = RankType.Head_Coach
        //    };

        //    _basketballInfoRepository.TeamForTeamIdExists(teamId).Returns(false);

        //    _basketballInfoRepository.GetCoachByTeamIdAndCoachIdAsyn(teamId, coachId).ReturnsNull();


        //    //Act
        //    var actual = _sut.GetCoachByTeamIdAndCoachId(teamId, coachId);

        //    //Assert
        //    Assert.Null(actual);

        //}

        //[Fact]
        //public void GetCoachByCoachIdAndTeamId_ShouldReturnNull_InvalidCoachId()
        //{
        //    //Arrange
        //    var teamId = 1;
        //    var coachId = 0;

        //    var coachInfo = new Coach()
        //    {
        //        CoachId = 1,
        //        FirstName = "Sean",
        //        LastName = "Pietersen",
        //        YearsOfExperience = 1,
        //        IsQualified = false,
        //        Rank = RankType.Head_Coach
        //    };

        //    _basketballInfoRepository.TeamForTeamIdExists(teamId).Returns(true);

        //    _basketballInfoRepository.GetCoachByTeamIdAndCoachIdAsyn(teamId, coachId).ReturnsNull();


        //    //Act
        //    var actual = _sut.GetCoachByTeamIdAndCoachId(teamId, coachId);

        //    //Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void GetCoachByCoachIdAndTeamId_IsSuccessful()
        //{
        //    //Arrange
        //    var teamId = 1;
        //    var coachId = 1;

        //    var coachInfo = new Coach()
        //    {
        //        CoachId = 1,
        //        FirstName = "Sean",
        //        LastName = "Pietersen",
        //        YearsOfExperience = 1,
        //        IsQualified = false,
        //        Rank = RankType.Head_Coach
        //    };

        //    _basketballInfoRepository.TeamForTeamIdExists(teamId).Returns(true);

        //    _basketballInfoRepository.GetCoachByTeamIdAndCoachIdAsyn(teamId, coachId).Returns(coachInfo);


        //    //Act
        //    CoachDto actual = _sut.GetCoachByTeamIdAndCoachId(teamId, coachId);

        //    //Assert
        //    Assert.Equal(coachInfo.FirstName, actual.FirstName);
        //    Assert.Equal(coachInfo.LastName, actual.LastName);
        //}

        //[Fact]
        //public void CreateCoachByCoachId_ShouldReturnNull_InvalidTeamId()
        //{
        //    //Arrange
        //    int teamId = 0;

        //    CoachForCreationDto coachDto = new CoachForCreationDto()
        //    {
        //        FirstName = "Rumer",
        //        LastName = "Manis",
        //        YearsOfExperience = 5,
        //        IsQualified = true,
        //        Rank = RankType.Head_Coach
        //    };

        //    _basketballInfoRepository.GetTeamByTeamIdAsync(teamId, false, true).ReturnsNull();

        //    //Act
        //    CoachDto actual = _sut.CreateCoachByCoachId(teamId, coachDto).Result;

        //    //Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void CreateCoachByCoachId_IsSuccessful()
        //{
        //    //Arrange
        //    int teamId = 1;

        //    var teamInDb = new Team()
        //    {
        //        TeamId = 1,
        //        Name = "Mock Test 1",
        //        State = "Los Angalese"
        //    };

        //    var coachInDb = new List<Coach>()
        //    {
        //        new Coach()
        //        {
        //            CoachId = 1,
        //            FirstName = "Jason",
        //            LastName = "Pietersen",
        //            YearsOfExperience = 5,
        //            IsQualified = true,
        //            Rank = RankType.Head_Coach
        //        },
        //        new Coach()
        //        {
        //            CoachId = 2,
        //            FirstName = "Sean",
        //            LastName = "Pietersen",
        //            YearsOfExperience = 5,
        //            IsQualified = true,
        //            Rank = RankType.Head_Coach
        //        }
        //    };

        //    CoachForCreationDto coachDto = new CoachForCreationDto()
        //    {
        //        FirstName = "Rumer",
        //        LastName = "Manis",
        //        YearsOfExperience = 5,
        //        IsQualified = true,
        //        Rank = RankType.Head_Coach
        //    };

        //    Coach coach = new Coach()
        //    {
        //        FirstName = "Rumer",
        //        LastName = "Manis",
        //        YearsOfExperience = 5,
        //        IsQualified = true,
        //        Rank = RankType.Head_Coach
        //    };

        //    _basketballInfoRepository.TeamForTeamIdExists(teamId).Returns(true);

        //    _basketballInfoRepository.CreateCoachByCoachIdAsync(teamId, Arg.Any<Coach>());

        //    _basketballInfoRepository.SaveChangesAsync().Returns(true);


        //    //Act
        //    CoachDto actual = _sut.CreateCoachByCoachId(teamId, coachDto).Result;

        //    //Assert
        //    Assert.Equal(coach.FirstName, actual.FirstName);
        //    Assert.Equal(coach.LastName, actual.LastName);
        //    Assert.Equal(coach.Rank, actual.Rank);
        //}

        //[Fact]
        //public void UpdateCoachByCoachId_ShouldReturnNull_InvalidTeamId()
        //{
        //    //Arrange
        //    int teamId = 0;

        //    int coachId = 1;

        //    _basketballInfoRepository.GetTeamByTeamIdAsync(teamId, false, true).ReturnsNull();

        //    //Act
        //    var actual = _sut.UpdateCoachByCoachId(teamId, coachId, null).Result;

        //    //Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void UpdateCoachByCoachId_ShouldReturnNull_InvalidCoachId()
        //{
        //    //Arrange

        //    int teamId = 1;

        //    int coachId = 0;

        //    var teamInDb = new Team()
        //    {
        //        TeamId = 1,
        //        Name = "Mock Test 1",
        //        State = "Los Angalese",
        //        Coaches = new List<Coach>()
        //        {
        //            new Coach()
        //            {
        //                CoachId = 1,
        //                FirstName = "Jason",
        //                LastName = "Pietersen",
        //                YearsOfExperience = 5,
        //                IsQualified = true,
        //                Rank = RankType.Head_Coach
        //            },
        //            new Coach()
        //            {
        //                CoachId = 2,
        //                FirstName = "Sean",
        //                LastName = "Pietersen",
        //                YearsOfExperience = 5,
        //                IsQualified = true,
        //                Rank = RankType.Head_Coach
        //            }
        //        }
        //    };

        //    _basketballInfoRepository.TeamForTeamIdExists(teamId).Returns(true);

        //    _basketballInfoRepository.GetCoachByTeamIdAndCoachIdAsyn(teamId, coachId).ReturnsNull();

        //    //Act
        //    var actual = _sut.UpdateCoachByCoachId(teamId, coachId, null).Result;

        //    //Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void UpdateCoachByCoachId_IsSuccessful()
        //{
        //    //Arrange

        //    int teamId = 1;

        //    int coachId = 0;

        //    var teamInDb = new Team()
        //    {
        //        TeamId = 1,
        //        Name = "Mock Test 1",
        //        State = "Los Angalese",
        //        Coaches = new List<Coach>()
        //        {
        //            new Coach()
        //            {
        //                CoachId = 1,
        //                FirstName = "Jason",
        //                LastName = "Pietersen",
        //                YearsOfExperience = 5,
        //                IsQualified = true,
        //                Rank = RankType.Head_Coach
        //            },
        //            new Coach()
        //            {
        //                CoachId = 2,
        //                FirstName = "Sean",
        //                LastName = "Pietersen",
        //                YearsOfExperience = 5,
        //                IsQualified = true,
        //                Rank = RankType.Head_Coach
        //            }
        //        }
        //    };

        //    var coachInDb = new Coach()
        //    {
        //        CoachId = 2,
        //        FirstName = "Sean",
        //        LastName = "Pietersen",
        //        YearsOfExperience = 5,
        //        IsQualified = true,
        //        Rank = RankType.Head_Coach
        //    };

        //    var coachForUpdateDto = new CoachForUpdateDto()
        //    {
        //        FirstName = "Update-Sean",
        //        LastName = "Pietersen",
        //        YearsOfExperience = 5,
        //        IsQualified = false,
        //        Rank = RankType.Head_Coach
        //    };

        //    _basketballInfoRepository.TeamForTeamIdExists(teamId).Returns(true);

        //    _basketballInfoRepository.GetTeamByTeamIdAsync(teamId, false, true).Returns(teamInDb);

        //    _basketballInfoRepository.GetCoachByTeamIdAndCoachIdAsyn(teamId, coachId).Returns(coachInDb);

        //    //Act
        //    var actual = _sut.UpdateCoachByCoachId(teamId, coachId, coachForUpdateDto).Result;

        //    //Assert
        //    Assert.Equal(coachForUpdateDto.FirstName, actual.FirstName);
        //    Assert.Equal(coachForUpdateDto.IsQualified, actual.IsQualified);
        //}

        //[Fact]
        //public void DeleteCoachByCoachId_ShouldReturnNull_InvalidTeam()
        //{
        //    //Arrange
        //    var teamId = 0;

        //    int coachId = 1;

        //    _basketballInfoRepository.GetTeamByTeamIdAsync(teamId, false, true).ReturnsNull();

        //    //Act
        //    var actual = _sut.DeleteCoachByCoachId(teamId, coachId).Result;

        //    //Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void DeleteCoachByCoachId_ShouldReturnNull_InvalidCoachId()
        //{
        //    //Arrange

        //    int teamId = 1;

        //    int coachId = 0;


        //    var teamInDb = new Team()
        //    {
        //        TeamId = 1,
        //        Name = "Mock Test 1",
        //        State = "Los Angalese",
        //        Coaches = new List<Coach>()
        //        {
        //            new Coach()
        //            {
        //                CoachId = 1,
        //                FirstName = "Jason",
        //                LastName = "Pietersen",
        //                YearsOfExperience = 5,
        //                IsQualified = true,
        //                Rank = RankType.Head_Coach
        //            },
        //            new Coach()
        //            {
        //                CoachId = 2,
        //                FirstName = "Sean",
        //                LastName = "Pietersen",
        //                YearsOfExperience = 5,
        //                IsQualified = true,
        //                Rank = RankType.Head_Coach
        //            }
        //        }
        //    };

        //    _basketballInfoRepository.GetTeamByTeamIdAsync(teamId, false, true).Returns(teamInDb);

        //    _basketballInfoRepository.GetCoachByTeamIdAndCoachIdAsyn(teamId, coachId).ReturnsNull();

        //    //Act
        //    var actual = _sut.DeleteCoachByCoachId(teamId, coachId).Result;

        //    //Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void DeleteCoachByCoachId_IsSuccessful()
        //{
        //    //Arrange

        //    int teamId = 1;

        //    int coachId = 1;

        //    var coachInDb = new Coach()
        //    {
        //        CoachId = 1,
        //        FirstName = "Jason",
        //        LastName = "Pietersen",
        //        YearsOfExperience = 5,
        //        IsQualified = true,
        //        Rank = RankType.Head_Coach
        //    };

        //    var teamInDb = new Team()
        //    {
        //        TeamId = 1,
        //        Name = "Mock Test 1",
        //        State = "Los Angalese",
        //        Coaches = new List<Coach>()
        //        {
        //            new Coach()
        //            {
        //                CoachId = 1,
        //                FirstName = "Jason",
        //                LastName = "Pietersen",
        //                YearsOfExperience = 5,
        //                IsQualified = true,
        //                Rank = RankType.Head_Coach
        //            },
        //            new Coach()
        //            {
        //                CoachId = 2,
        //                FirstName = "Sean",
        //                LastName = "Pietersen",
        //                YearsOfExperience = 5,
        //                IsQualified = true,
        //                Rank = RankType.Head_Coach
        //            }
        //        }
        //    };

        //    _basketballInfoRepository.TeamForTeamIdExists(teamId).Returns(true);

        //    _basketballInfoRepository.GetCoachByTeamIdAndCoachIdAsyn(teamId, coachId).Returns(coachInDb);

        //    _basketballInfoRepository.SaveChangesAsync().Returns(true);

        //    //Act
        //    var actual = _sut.DeleteCoachByCoachId(teamId, coachId).Result;

        //    //Assert
        //    Assert.Equal(coachInDb.FirstName, actual.FirstName);
        //    Assert.Equal(coachInDb.LastName, actual.LastName);
        //}
    }
}
