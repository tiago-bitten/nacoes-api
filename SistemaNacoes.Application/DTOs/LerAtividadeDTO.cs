namespace SistemaNacoes.Application.DTOs
{
    public class LerAtividadeDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MaximoVoluntarios { get; set; }
        public bool? Ativo { get; set; }
        public int? MinisterioId { get; set; }
    }
}
