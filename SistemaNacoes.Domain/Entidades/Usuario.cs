namespace SistemaNacoes.Domain.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool? Aprovado { get; set; }
        public bool? Admin { get; set; }

        public ICollection<UsuarioMinisterio> UsuariosMinisterios { get; set; }
        public ICollection<Historico> Historicos { get; set; }
    }
}
