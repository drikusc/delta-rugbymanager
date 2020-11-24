using Microsoft.Extensions.Configuration;
using RugbyManager.DataAccess.Models;
using System.IO;

namespace RugbyManager.DataAccess.Utils
{
    public class DatabaseConfiguration
    {
        private readonly string _connectionString = string.Empty;

        public DatabaseConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _connectionString = root.GetSection(ConfigurationStruct.DATABASE).GetSection(DatabaseConfigurationStruct.CONNECTION_STRING).Value;
        }

        public string ConnectionString
        {
            get => _connectionString;
        }
    }
}
