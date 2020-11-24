using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace RugbyManager.UnitTests.Services
{
    public class DependencySetupFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public DependencySetupFixture()
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", false, true);
            var configuration = builder.Build();

            var services = Utils.DependencyInjector.ConfigureServices(new ServiceCollection(), configuration);

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
