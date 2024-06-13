using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infrastructure.Persistence.Data;

namespace SistemaNacoes.Infrastructure.Persistence.Repositorios
{
    public class AgendamentoRepository : IAgendamentoRepository
    {

        private readonly SistemaNacoesDbContext _context;

        public AgendamentoRepository(SistemaNacoesDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(Agendamento entity)
        {
            await _context.Agendamentos.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Agendamento entity)
        {
            _context.Agendamentos.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Agendamento>> GetAllAsync()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        public async Task<Agendamento?> GetByIdAsync(int id)
        {
            return await _context.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Agendamento entity)
        {
            await _context.SaveChangesAsync();
        }
    }
}
