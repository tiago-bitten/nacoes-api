using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades
{
    public sealed class Agenda : EntidadeBase
    {
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public bool Finalizado { get; private set; } = false;

        public List<Agendamento> Agendamentos { get; set; } = new();
        public List<Escala> Escalas { get; set; } = new();

        public void Finalizar()
        {
            Finalizado = true;
        }

        #region regras
        public void VerificaGaranteDisponibilidade()
        {
            if (Removido || Finalizado)
                throw new DominioException(ErroRegraDominio.AgendaIndisponivel);
        }
        #endregion
    }
}
