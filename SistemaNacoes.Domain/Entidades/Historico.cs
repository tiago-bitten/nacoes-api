namespace SistemaNacoes.Domain.Entidades
{
    public class Historico
    {
        public int Id { get; set; }
        public string Tabela { get; set; }
        public string Operacao { get; set; }
        public int RegistroId { get; set; }
        public string DadosAnteriores { get; set; }
        public string DadosNovos { get; set; }
        public DateTime AlteradoEm { get; set; } = DateTime.Now;
        public int? UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
