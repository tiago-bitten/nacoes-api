using SistemaNacoes.Application.Dtos.Ministerios;

namespace SistemaNacoes.Application.Dtos.Grupos;

public class GetGrupoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public GetMinisterioDto MinisterioPrefencial { get; set; }
}