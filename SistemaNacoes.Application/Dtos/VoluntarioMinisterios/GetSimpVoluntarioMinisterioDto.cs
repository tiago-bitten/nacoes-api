using SistemaNacoes.Application.Dtos.Ministerios;
using SistemaNacoes.Application.Dtos.Voluntarios;

namespace SistemaNacoes.Application.Dtos.VoluntarioMinisterios;

public class GetSimpVoluntarioMinisterioDto
{
    public GetSimpVoluntarioDto Voluntario { get; set; }
    public GetMinisterioDto Ministerio { get; set; }
}