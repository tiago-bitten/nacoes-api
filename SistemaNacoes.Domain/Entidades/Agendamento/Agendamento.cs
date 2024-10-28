using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Agendamento
{
    public sealed class Agendamento : EntidadeBase
    {
        public Agendamento()
        {
        }
        
        public Agendamento(Voluntario voluntario, Ministerio.Ministerio ministerio, Agenda.Agenda agenda)
        {
            Voluntario = voluntario;
            Ministerio = ministerio;
            Agenda = agenda;
        }
        
        public int VoluntarioId { get; set; }
        public int MinisterioId { get; set; }
        public int AgendaId { get; set; }

        public Voluntario Voluntario { get; set; }
        public Ministerio.Ministerio Ministerio { get; set; }
        public Agenda.Agenda Agenda { get; set; }
        public List<AgendamentoAtividade.AgendamentoAtividade> AgendamentoAtividades { get; set; } = new();
    }
}
