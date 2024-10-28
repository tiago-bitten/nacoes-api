using SistemaNacoes.Domain.Entidades.Abstracoes;
using SistemaNacoes.Domain.Entidades.Infra;

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

        public Ministerio Ministerio { get; set; }
        public List<EscalaItem> EscalaItens { get; set; } = new();
        public List<AgendamentoAtividade.AgendamentoAtividade> AgendamentoAtividades { get; set; } = new();
    }
}
