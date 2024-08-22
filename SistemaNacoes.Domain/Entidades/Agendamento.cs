using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades
{
    public sealed class Agendamento : EntidadeBase
    {
        public Agendamento()
        {
        }
        
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
        public List<AgendamentoAtividade> AgendamentoAtividades { get; set; } = new();
        public SituacaoAgendamento SituacaoAgendamento { get; set; }
    }
}
