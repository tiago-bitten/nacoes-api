using SistemaNacoes.Application.Dtos.Atividades;
using SistemaNacoes.Application.Dtos.Ministerios;
using SistemaNacoes.Application.Dtos.VoluntarioMinisterios;
using SistemaNacoes.Application.Dtos.Voluntarios;

namespace SistemaNacoes.Application.Dtos.Agendamentos;

public class GetAgendamentoDto
{
    public int Id { get; set; }
    public GetSimpVoluntarioDto Voluntario { get; set; }
    public GetMinisterioDto Ministerio { get; set; }
    public List<GetSimpAtividadeDto>? Atividades { get; set; }
}