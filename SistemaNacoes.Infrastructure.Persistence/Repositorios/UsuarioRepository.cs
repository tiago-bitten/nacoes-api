using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infrastructure.Persistence.Data;

namespace SistemaNacoes.Infrastructure.Persistence.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly SistemaNacoesDbContext _context;

        public UsuarioRepository(SistemaNacoesDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateAsync(Usuario entity)
        {
            await _context.Usuarios.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Usuario entity)
        {
            _context.Usuarios.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario?>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Usuario entity)
        {
            _context.Usuarios.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
