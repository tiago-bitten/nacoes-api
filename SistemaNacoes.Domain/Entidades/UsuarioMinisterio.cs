namespace SistemaNacoes.Domain.Entidades
{
    public class UsuarioMinisterio
    {
        public UsuarioMinisterio(Usuario usuario, Ministerio ministerio)
        {
            Usuario = usuario;
            Ministerio = ministerio;
        }
        
        public int UsuarioId { get; set; }
        public int MinisterioId { get; set; }
        public bool Ativo { get; set; } = true;

        public Usuario Usuario { get; set; }
        public Ministerio Ministerio { get; set; }
    }
}
