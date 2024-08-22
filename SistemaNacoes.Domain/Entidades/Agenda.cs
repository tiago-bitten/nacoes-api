using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades
{
    public sealed class Agenda : EntidadeBase
    {
        public Agenda() {}

        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public bool Ativo { get; set; } = true;
        public bool Finalizado { get; set; } = false;

        public List<Agendamento> Agendamentos { get; set; } = new();
        public List<Escala> Escalas { get; set; } = new();

        public void Close()
        {
            Ativo = false;
        }
        
        public void Finalize()
        {
            Finalizado = true;
        }
    }
}
