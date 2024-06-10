namespace SistemaNacoes.Domain.Entidades
{
    public class Escala
    {
        public int Id { get; set; }
        public int QuantidadeVoluntarios { get; set; }
        public int? AgendaId { get; set; }
        public int? MinisterioId { get; set; }
        public bool? Usada { get; set; }

        public Agenda Agenda { get; set; }
        public Ministerio Ministerio { get; set; }
        public ICollection<EscalaItem> EscalaItens { get; set; }
        public ICollection<EscalaVoluntario> EscalasVoluntarios { get; set; }
    }
}
