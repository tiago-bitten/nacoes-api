namespace SistemaNacoes.Domain.Entidades
{
    public class UsuarioMinisterio
    {
        public int UsuarioId { get; set; }
        public int MinisterioId { get; set; }
        public bool? Ativo { get; set; }

        public Usuario Usuario { get; set; }
        public Ministerio Ministerio { get; set; }
    }
}
