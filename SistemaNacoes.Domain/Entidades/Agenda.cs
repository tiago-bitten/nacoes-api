namespace SistemaNacoes.Domain.Entidades
{
    public class Agenda : EntidadeBase
    {
        public Agenda(string titulo, string descricao, DateTime dataInicio, DateTime dataFinal)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFinal = dataFinal;
        }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public bool Ativo { get; set; } = true;

        public List<Agendamento> Agendamentos { get; set; } = new();
        public List<Escala> Escalas { get; set; } = new();
    }
}
