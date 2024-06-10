namespace SistemaNacoes.Domain.Entidades
{
    public class Atividade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MaximoVoluntarios { get; set; }
        public bool? Ativo { get; set; }
        public int? MinisterioId { get; set; }

        public Ministerio Ministerio { get; set; }
        public ICollection<EscalaItem> EscalaItens { get; set; }
    }
}
