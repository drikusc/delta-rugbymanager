using Microsoft.Extensions.DependencyInjection;
using RugbyManager.Contracts;
using Xunit;

namespace RugbyManager.UnitTests.Services
{
    public class PlayerServiceTest : IClassFixture<DependencySetupFixture>
    {
        private ServiceProvider _serviceProvider;

        public PlayerServiceTest(DependencySetupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void Create_InvalidBirthDate()
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var playerService = scope.ServiceProvider.GetService<IPlayerService>();
                var response = playerService.Create(new Models.CreatePlayerRequest());

                Assert.Equal(13, response.Code);
            }
        }

        [Fact]
        public void Create_InvalidPositionCode()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var playerService = scope.ServiceProvider.GetService<IPlayerService>();
                var response = playerService.Create(new Models.CreatePlayerRequest
                {
                    BirthDate = "01011995"
                });

                Assert.Equal(14, response.Code);
            }
        }

        [Fact]
        public void Create_InvalidTeamId()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var playerService = scope.ServiceProvider.GetService<IPlayerService>();
                var response = playerService.Create(new Models.CreatePlayerRequest
                {
                    BirthDate = "01011995",
                    PositionCode = "PROP_LOOSE"
                });

                Assert.Equal(15, response.Code);
            }
        }

        [Fact]
        public void Create_Success()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var playerService = scope.ServiceProvider.GetService<IPlayerService>();
                var response = playerService.Create(new Models.CreatePlayerRequest
                {
                    BirthDate = "01011995",
                    PositionCode = "PROP_LOOSE",
                    FirstName = "Piet",
                    LastName = "Roomys",
                    TeamId = 1,
                    Height = null
                });

                Assert.Equal(0, response.Code);
            }
        }

        [Fact]
        public void Transfer_InvalidPlayerId()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var playerService = scope.ServiceProvider.GetService<IPlayerService>();
                var response = playerService.Transfer(new Models.TransferPlayerRequest());

                Assert.Equal(16, response.Code);
            }
        }

        [Fact]
        public void Transfer_InvalidTeamId()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var playerService = scope.ServiceProvider.GetService<IPlayerService>();
                var response = playerService.Transfer(new Models.TransferPlayerRequest
                {
                    PlayerId = 3,
                    TeamId = 50
                });

                Assert.Equal(15, response.Code);
            }
        }

        [Fact]
        public void Transfer_Success()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var playerService = scope.ServiceProvider.GetService<IPlayerService>();
                var response = playerService.Transfer(new Models.TransferPlayerRequest
                {
                    PlayerId = 3,
                    TeamId = 1
                });

                Assert.Equal(0, response.Code);
            }
        }
    }
}
