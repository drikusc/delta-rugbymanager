using Microsoft.Extensions.DependencyInjection;
using RugbyManager.Contracts;
using Xunit;

namespace RugbyManager.UnitTests.Services
{
    public class StadiumServiceTest : IClassFixture<DependencySetupFixture>
    {
        private ServiceProvider _serviceProvider;

        public StadiumServiceTest(DependencySetupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void Create_DuplicateStadiumName()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var stadiumService = scope.ServiceProvider.GetService<IStadiumService>();
                var response = stadiumService.Create(new Models.CreateStadiumRequest
                {
                    Name = "Ellis Park"
                });

                Assert.Equal(17, response.Code);
            }
        }

        [Fact]
        public void Create_Success()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var stadiumService = scope.ServiceProvider.GetService<IStadiumService>();
                var response = stadiumService.Create(new Models.CreateStadiumRequest
                {
                    Name = "Outeniqua Park",
                    City = "George",
                    Province = "Western Cape"
                });

                Assert.Equal(0, response.Code);
            }
        }
    }
}
