using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades
{
    public class Voluntario : Pessoa
    {
        public Voluntario() {}
        
        public Guid ChaveAcesso { get; set; } = Guid.NewGuid();
        public bool Removido { get; set; } = false;

        public List<GrupoVoluntario> GrupoVoluntarios { get; set; } = new();

        public List<VoluntarioMinisterio> VoluntarioMinisterios { get; set; } = new();
        public List<Agendamento> Agendamentos { get; set; } = new();
        public List<DataIndisponivel> DatasIndisponiveis { get; set; } = new();
        public List<EscalaItem> EscalaItens { get; set; } = new();
    }
}
