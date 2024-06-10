namespace SistemaNacoes.Domain.Entidades
{
    public class VoluntarioMinisterio
    {
        public int VoluntarioId { get; set; }
        public int MinisterioId { get; set; }
        public bool? Ativo { get; set; }

        public Voluntario Voluntario { get; set; }
        public Ministerio Ministerio { get; set; }
    }
}
