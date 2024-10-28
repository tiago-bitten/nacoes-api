using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Entidades
{
    public sealed class Usuario : Pessoa
    {
        public Usuario() {}
        
        public string SenhaHash { get; set; }
        public int PerfilAcessoId { get; set; }

        public PerfilAcesso PerfilAcesso { get; set; }
        public List<UsuarioMinisterio> UsuariosMinisterios { get; set; } = new();
        public List<HistoricoLogin.HistoricoLogin> RegistroLogins { get; set; } = new();
        public List<HistoricoEntidade.HistoricoEntidade> Historicos { get; set; } = new();
    }
}