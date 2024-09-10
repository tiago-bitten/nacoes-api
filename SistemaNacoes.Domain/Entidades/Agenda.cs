using SistemaNacoes.Domain.Enterprise;
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
        public bool Finalizado { get; set; } = false;

        public List<Agendamento> Agendamentos { get; set; } = new();
        public List<Escala> Escalas { get; set; } = new();

        public void Finalize()
        {
            Finalizado = true;
        }

        #region regras
        public void CheckStatus()
        {
            if (Removido || Finalizado)
                throw new DominioException(ErroRegraDominio.AgendaIndisponivel);
        }
        #endregion
    }
}
