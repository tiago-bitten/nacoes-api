using System;
using System.Collections.Generic;

namespace SistemaNacoes.Domain.Entidades
{
    public class Agenda
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public bool? Ativo { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; }
        public ICollection<Escala> Escalas { get; set; }
    }
}
