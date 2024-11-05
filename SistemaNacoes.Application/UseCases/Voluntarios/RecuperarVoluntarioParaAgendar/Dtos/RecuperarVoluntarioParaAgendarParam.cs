using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Voluntarios.RecuperarVoluntarioParaAgendar.Dtos;

public class RecuperarVoluntarioParaAgendarParam : Param
{   
    public int AgendarId { get; set; }
    public int MinisterioId { get; set; }
}