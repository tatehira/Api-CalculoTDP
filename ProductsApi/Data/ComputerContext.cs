using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Data
{
    public class ComputerContext : DbContext
    {
        public ComputerContext(DbContextOptions<ComputerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }

        public DbSet<ComputerComponents> Computers { get; set; }
    }
}
