namespace SistemaNacoes.Domain.Entidades
{
    public class Atividade : EntidadeBase
    {
        public Atividade(string nome, Ministerio ministerio)
        {
            Nome = nome;
            Ministerio = ministerio;
        }
        
        public string Nome { get; set; }
        public int MaximoVoluntarios { get; set; }
        public int MinisterioId { get; set; }
        public bool Removido { get; set; } = false;

        public Ministerio Ministerio { get; set; }
        public List<EscalaItem> EscalaItens { get; set; } = new();
    }
}
