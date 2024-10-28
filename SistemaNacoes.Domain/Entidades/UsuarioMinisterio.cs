using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades
{
    public sealed class UsuarioMinisterio : EntidadeBase
    {
        public UsuarioMinisterio() {}
        
        public UsuarioMinisterio(Usuario usuario, Ministerio ministerio)
        {
            Usuario = usuario;
            Ministerio = ministerio;
        }
        
        public int UsuarioId { get; set; }
        public int MinisterioId { get; set; }

        public Usuario Usuario { get; set; }
        public Ministerio Ministerio { get; set; }
    }
}
