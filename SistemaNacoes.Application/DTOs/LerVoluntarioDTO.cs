namespace SistemaNacoes.Application.DTOs
{
    public class LerVoluntarioDTO
    {
        public int Id { get; set; }
        public Guid AccessKey { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? GrupoId { get; set; }
    }
}
