﻿using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades.Infra;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Domain.Entidades.Agenda
{
    public sealed class Agenda : EntidadeBase
    {
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public EAgendaStatus Status { get; private set; } = EAgendaStatus.Aberto;

        public List<Agendamento.Agendamento> Agendamentos { get; set; } = new();
        public List<Escala.Escala> Escalas { get; set; } = new();

        public void Concluir()
        {
            Status = EAgendaStatus.Concluido;
        }

        #region regras
        public void ValidarStatus()
        {
            if (Status is EAgendaStatus.Concluido or EAgendaStatus.Fechado)
                throw new DominioException(ErroRegraDominio.AgendaIndisponivel);
        }
        #endregion
    }
}
