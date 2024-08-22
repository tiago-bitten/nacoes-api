using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades
{
    public sealed class Atividade : EntidadeBase
    {
        public Atividade() {}
        public Atividade(string nome, int maximoVoluntarios, Ministerio ministerio)
        {
            Nome = nome;
            MaximoVoluntarios = maximoVoluntarios;
            Ministerio = ministerio;
        }
        
        public string Nome { get; set; }
        public int MaximoVoluntarios { get; set; }
        public int MinisterioId { get; set; }
        public bool Removido { get; set; } = false;

        public Ministerio Ministerio { get; set; }
        public List<EscalaItem> EscalaItens { get; set; } = new();
        public List<AgendamentoAtividade> AgendamentoAtividades { get; set; } = new();
    }
}
