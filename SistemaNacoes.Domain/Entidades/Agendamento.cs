namespace SistemaNacoes.Domain.Entidades
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int? VoluntarioId { get; set; }
        public int? MinisterioId { get; set; }
        public int? AgendaId { get; set; }

        public Voluntario Voluntario { get; set; }
        public Ministerio Ministerio { get; set; }
        public Agenda Agenda { get; set; }
    }
}
