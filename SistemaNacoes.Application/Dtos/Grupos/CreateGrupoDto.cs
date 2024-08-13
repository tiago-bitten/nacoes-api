namespace SistemaNacoes.Application.Dtos.Grupos;

public class CreateGrupoDto
{
    public string Nome { get; set; }
    public int? MinisterioPreferencialId { get; set; }
    public List<int>? VoluntarioIds { get; set; }
}