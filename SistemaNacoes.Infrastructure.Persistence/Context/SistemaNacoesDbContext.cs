using Microsoft.EntityFrameworkCore;

namespace SistemaNacoes.Infrastructure.Persistence.Context
{
    public class SistemaNacoesDbContext : DbContext
    {
        public SistemaNacoesDbContext(DbContextOptions<SistemaNacoesDbContext> options)
            : base(options)
        {
        }
    }
}
