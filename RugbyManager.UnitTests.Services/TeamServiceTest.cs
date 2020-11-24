using Microsoft.Extensions.DependencyInjection;
using RugbyManager.Contracts;
using Xunit;

namespace RugbyManager.UnitTests.Services
{
    public class TeamServiceTest : IClassFixture<DependencySetupFixture>
    {
        private ServiceProvider _serviceProvider;

        public TeamServiceTest(DependencySetupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void Create_DuplicateTeamName()
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var teamService = scope.ServiceProvider.GetService<ITeamService>();
                var response = teamService.Create(new Models.CreateTeamRequest());

                Assert.Equal(12, response.Code);
            }
        }

        [Fact]
        public void Create_InvalidStadiumId()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var teamService = scope.ServiceProvider.GetService<ITeamService>();
                var response = teamService.Create(new Models.CreateTeamRequest
                {
                    StadiumId = 12
                });

                Assert.Equal(10, response.Code);
            }
        }

        [Fact]
        public void Create_TeamAlreadyLinkedToStadiumId()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var teamService = scope.ServiceProvider.GetService<ITeamService>();
                var response = teamService.Create(new Models.CreateTeamRequest
                {
                    StadiumId = 1
                });

                Assert.Equal(11, response.Code);
            }
        }

        [Fact]
        public void Create_Success()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var teamService = scope.ServiceProvider.GetService<ITeamService>();
                var response = teamService.Create(new Models.CreateTeamRequest
                {
                    StadiumId = 1,
                    Name = "Team Anti-Koala",
                    City = "Brakpan",
                    Province = "North-West"
                });

                Assert.Equal(0, response.Code);
            }
        }

        [Fact]
        public void LinkStadium_InvalidStadiumId()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var teamService = scope.ServiceProvider.GetService<ITeamService>();
                var response = teamService.LinkStadium(new Models.LinkTeamToStadiumRequest
                {
                    StadiumId = 18
                });

                Assert.Equal(10, response.Code);
            }
        }

        [Fact]
        public void LinkStadium_TeamAlreadyLinkedToStadiumId()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var teamService = scope.ServiceProvider.GetService<ITeamService>();
                var response = teamService.LinkStadium(new Models.LinkTeamToStadiumRequest
                {
                    StadiumId = 1,
                    TeamId = 1
                });

                Assert.Equal(11, response.Code);
            }
        }

        [Fact]
        public void LinkStadium_InvalidTeamId()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var teamService = scope.ServiceProvider.GetService<ITeamService>();
                var response = teamService.LinkStadium(new Models.LinkTeamToStadiumRequest
                {
                    StadiumId = 2,
                    TeamId = 60
                });

                Assert.Equal(15, response.Code);
            }
        }

        [Fact]
        public void LinkStadium_Success()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var teamService = scope.ServiceProvider.GetService<ITeamService>();
                var response = teamService.LinkStadium(new Models.LinkTeamToStadiumRequest
                {
                    StadiumId = 2,
                    TeamId = 1
                });

                Assert.Equal(0, response.Code);
            }
        }

        [Fact]
        public void UnlinkStadium_InvalidTeamId()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var teamService = scope.ServiceProvider.GetService<ITeamService>();
                var response = teamService.UnlinkStadium(new Models.UnlinkTeamToStadiumRequest
                {
                    TeamId = 60
                });

                Assert.Equal(15, response.Code);
            }
        }

        [Fact]
        public void UnlinkStadium_Success()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var teamService = scope.ServiceProvider.GetService<ITeamService>();
                var response = teamService.UnlinkStadium(new Models.UnlinkTeamToStadiumRequest
                {
                    TeamId = 1
                });

                Assert.Equal(0, response.Code);
            }
        }
    }
}
