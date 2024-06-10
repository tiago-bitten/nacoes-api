using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SistemaNacoes.Infrastructure.Persistence.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SistemaNacoesDbContext>
    {
        public SistemaNacoesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SistemaNacoesDbContext>();

            // Use your connection string here
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);

            return new SistemaNacoesDbContext(optionsBuilder.Options);
        }
    }
}
