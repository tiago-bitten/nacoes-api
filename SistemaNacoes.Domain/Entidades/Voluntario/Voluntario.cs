using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades.Voluntario;

public sealed class Voluntario : Pessoa
{
    public Voluntario() {}
        
    public Guid ChaveAcesso { get; set; } = Guid.NewGuid();

    public List<GrupoVoluntario.GrupoVoluntario> GrupoVoluntarios { get; set; } = new();

    public List<VoluntarioMinisterio.VoluntarioMinisterio> VoluntarioMinisterios { get; set; } = new();
    public List<Agendamento.Agendamento> Agendamentos { get; set; } = new();
    public List<DataIndisponivel.DataIndisponivel> DataIndisponiveis { get; set; } = new();
    public List<EscalaItem.EscalaItem> EscalaItens { get; set; } = new();
}