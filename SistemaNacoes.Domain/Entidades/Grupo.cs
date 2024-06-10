namespace SistemaNacoes.Domain.Entidades
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? MinisterioPreferencialId { get; set; }

        public Ministerio MinisterioPreferencial { get; set; }
        public ICollection<Voluntario> Voluntarios { get; set; }
    }
}
