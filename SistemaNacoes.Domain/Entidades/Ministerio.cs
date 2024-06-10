namespace SistemaNacoes.Domain.Entidades
{
    public class Ministerio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }

        public ICollection<Atividade> Atividades { get; set; }
        public ICollection<VoluntarioMinisterio> VoluntariosMinisterios { get; set; }
        public ICollection<UsuarioMinisterio> UsuariosMinisterios { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }
        public ICollection<Escala> Escalas { get; set; }
        public ICollection<Grupo> Grupos { get; set; }
    }
}
