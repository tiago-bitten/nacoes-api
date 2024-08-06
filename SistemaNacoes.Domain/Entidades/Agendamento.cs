namespace SistemaNacoes.Domain.Entidades
{
    public class Agendamento : EntidadeBase
    {
        public Agendamento(Voluntario voluntario, Ministerio ministerio, Agenda agenda)
        {
            Voluntario = voluntario;
            Ministerio = ministerio;
            Agenda = agenda;
        }
        
        public int VoluntarioId { get; set; }
        public int MinisterioId { get; set; }
        public int AgendaId { get; set; }
        public bool Removido { get; set; } = false;

        public Voluntario Voluntario { get; set; }
        public Ministerio Ministerio { get; set; }
        public Agenda Agenda { get; set; }
    }
}
