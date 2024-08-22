using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades
{
    public sealed class Usuario : Pessoa
    {
        public Usuario() {}
        
        public string SenhaHash { get; set; }
        public bool Removido { get; set; } = false;

        public List<UsuarioMinisterio> UsuariosMinisterios { get; set; } = new();
    }
}