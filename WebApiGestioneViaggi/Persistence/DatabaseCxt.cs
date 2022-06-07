using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApiGestioneViaggi.Models;

namespace WebApiGestioneViaggi.Persistence
{
    public class DatabaseCxt : DbContext
    {
        public readonly string _connectionString;

        public DatabaseCxt(DbContextOptions<DatabaseCxt> opts, IOptions<AppSettings> setting) : base(opts)
        {
            _connectionString = setting.Value.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Continent> Continent { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
    }
}
