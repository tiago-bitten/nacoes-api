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

        public async Task<Usuario?> AutenticarAsync(string email, string senha)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(x => x.Email == email);

            await Console.Out.WriteLineAsync($"Buscar usuário por email: {usuario?.Email}");

            if (usuario == null || !VerificarSenha(senha, usuario.Senha))
                return null;

            return usuario;
        }

        public bool VerificarSenha(string senha, string senhaHash)
        {
            Console.WriteLine($"Verificando senha: {BCrypt.Net.BCrypt.Verify(senha, senhaHash)}");
            return BCrypt.Net.BCrypt.Verify(senha, senhaHash);
        }
    }
}
