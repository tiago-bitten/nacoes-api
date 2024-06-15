namespace SistemaNacoes.Application.DTOs
{
    public class CriarUsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool? Aprovado { get; set; }
        public bool? Admin { get; set; }
    }
}
