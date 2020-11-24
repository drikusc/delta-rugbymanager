using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RugbyManager.Contracts;
using RugbyManager.DataAccess.Contracts;
using RugbyManager.DataAccess.Manager;
using RugbyManager.Models;
using RugbyManager.Services;

namespace RugbyManager.Utils
{
    public class DependencyInjector
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ResponseConfiguration>(configuration.GetSection(ConfigurationStruct.RESPONSE_SETTINGS));
            services.Configure<PlayerServiceConfiguration>(configuration.GetSection(ConfigurationStruct.PLAYER_SERVICE_SETTINGS));
            services.AddOptions();

            services.AddSingleton<IPlayerService, PlayerService>();
            services.AddSingleton<ITeamService, TeamService>();
            services.AddSingleton<IStadiumService, StadiumService>();
            services.AddSingleton<IPositionService, PositionService>();

            services.AddSingleton<IPlayerDataManager, PlayerDataManager>();
            services.AddSingleton<IPositionDataManager, PositionDataManager>();
            services.AddSingleton<ITeamDataManager, TeamDataManager>();
            services.AddSingleton<IStadiumDataManager, StadiumDataManager>();

            return services;
        }
    }
}
