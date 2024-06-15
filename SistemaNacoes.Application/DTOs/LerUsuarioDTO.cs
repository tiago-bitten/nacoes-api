namespace SistemaNacoes.Application.DTOs
{
    public class LerUsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool? Aprovado { get; set; }
        public bool? Admin { get; set; }
    }
}
