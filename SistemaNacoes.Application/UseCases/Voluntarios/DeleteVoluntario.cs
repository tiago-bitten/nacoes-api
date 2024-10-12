using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Voluntarios;

public class DeleteVoluntario
{
    private readonly IUnitOfWork _uow;
    private readonly IVoluntarioService _voluntarioService;

    public DeleteVoluntario(IUnitOfWork uow, IVoluntarioService voluntarioService)
    {
        _uow = uow;
        _voluntarioService = voluntarioService;
    }
    
    public async Task<RespostaBase<dynamic>> ExecuteAsync(int id)
    {
        var includes = new[] { nameof(Voluntario.VoluntarioMinisterios) };
        
        var voluntario = await _voluntarioService.RecuperaGaranteExisteAsync(id, includes: includes);

        _uow.Voluntarios.SoftDelete(voluntario);

        foreach (var voluntarioMinisterio in voluntario.VoluntarioMinisterios)
        {
            _uow.VoluntarioMinisterios.SoftDelete(voluntarioMinisterio);
        }
        
        await _uow.CommitAsync();
        
        return new RespostaBase<dynamic>(RespostaBaseMensagem.DeleteVoluntario);
    }
}