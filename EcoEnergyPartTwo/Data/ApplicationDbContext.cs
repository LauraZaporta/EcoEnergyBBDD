using EcoEnergyBBDD.Models.BD;
using EcoEnergyPartTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoEnergyBBDD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Simulacions> Simulacions { get; set; }
        public DbSet<ConsumsAigua> ConsumsAigua { get; set; }
        public DbSet<IndicadorsEnergetics> IndicadorsEnergetics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettingsconn.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        }
    }
}