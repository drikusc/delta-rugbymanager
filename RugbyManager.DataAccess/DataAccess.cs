using Microsoft.EntityFrameworkCore;
using RugbyManager.DataAccess.Models;

namespace RugbyManager.DataAccess
{
    public class DataAccess : DbContext
    {
        private static string _connectionString;

        public DataAccess()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
                _connectionString = new Utils.DatabaseConfiguration().ConnectionString;
        }

        public DbSet<Stadium> Stadiums { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_connectionString);
    }
}
