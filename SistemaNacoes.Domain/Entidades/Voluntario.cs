namespace SistemaNacoes.Domain.Entidades
{
    public class Voluntario
    {
        public int Id { get; set; }
        public Guid AccessKey { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? GrupoId { get; set; }

        public Grupo Grupo { get; set; }
        public ICollection<VoluntarioMinisterio> VoluntariosMinisterios { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }
        public ICollection<DataIndisponivel> DatasIndisponiveis { get; set; }
        public ICollection<EscalaVoluntario> EscalasVoluntarios { get; set; }
    }
}
