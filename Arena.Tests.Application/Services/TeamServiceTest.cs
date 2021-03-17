using Arena.Application.Services;
using Arena.Domain.Entities;
using Arena.Domain.Interfaces.Services;
using Arena.Infra.Data.Context;
using Arena.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Arena.Tests.Application.Services
{
    public class TeamServiceTest
    {
        [Fact]
        public void ShouldGetTeamsList()
        {
            // arrange
            var teamList = new List<Team>() { new Team() { Name = "Dionin" } };
            var contextOptionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("testing");
            var teamServiceMock = new Mock<ITeamService>().Setup(service => service.List()).Returns(teamList);

            using (var db = new ArenaContext(contextOptionsBuilder.Options))
            {
                db.Set<Team>().AddRange(teamList);
                db.SaveChanges();
            }

            using (var db = new ArenaContext(contextOptionsBuilder.Options))
            {
                using var unitOfWork = new UnitOfWork(db);
                var service = new TeamService(unitOfWork);

                // act
                var result = service.List();

                // assert
                Assert.NotNull(result);
                Assert.Equal(teamList.Count, result.Count());
            }
        }
    }
}
