namespace SistemaNacoes.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
        
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Removido { get; set; } = false;

        public List<UsuarioMinisterio> UsuariosMinisterios { get; set; } = new();
    }
}