using SistemaNacoes.Application.Responses;
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
        var voluntario = await _voluntarioService.GetAndEnsureExistsAsync(id);

        _uow.Voluntarios.SoftDeleteAsync(voluntario);

        foreach (var voluntarioMinisterio in voluntario.VoluntariosMinisterios)
        {
            _uow.VoluntarioMinisterios.SoftDeleteAsync(voluntarioMinisterio);
        }
        
        await _uow.CommitAsync();
        
        return new RespostaBase<dynamic>(MensagemRepostasConstant.DeleteVoluntario);
    }
}