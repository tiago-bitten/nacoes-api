﻿using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.Escala
{
    public sealed class Escala : EntidadeBase
    {
        public Escala() {}
        public Escala(int quantidadeVoluntarios, Agenda.Agenda agenda, Ministerio.Ministerio ministerio)
        {
            QuantidadeVoluntarios = quantidadeVoluntarios;
            Agenda = agenda;
            Ministerio = ministerio;
        }

        public int QuantidadeVoluntarios { get; set; }
        public int AgendaId { get; set; }
        public int MinisterioId { get; set; }
        public bool Usada { get; set; } = false;
        public bool Removido { get; set; } = false;

        public Agenda.Agenda Agenda { get; set; }
        public Ministerio.Ministerio Ministerio { get; set; }
        public List<EscalaItem.EscalaItem> EscalaItens { get; set; } = new();
    }
}
