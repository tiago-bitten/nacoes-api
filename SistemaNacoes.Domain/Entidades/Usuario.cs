using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Entidades
{
    public sealed class Usuario : Pessoa
    {
        public Usuario() {}
        
        public string SenhaHash { get; set; }
        public EPermissoes Permissoes { get; set; }
        public bool Removido { get; set; } = false;

        public List<UsuarioMinisterio> UsuariosMinisterios { get; set; } = new();
        public List<RegistroLogin> RegistroLogins { get; set; } = new();
    }
}