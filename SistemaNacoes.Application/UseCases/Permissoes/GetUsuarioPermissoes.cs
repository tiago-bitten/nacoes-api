using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Permissoes;

public class GetUsuarioPermissoes
{
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;

    public GetUsuarioPermissoes(IAmbienteUsuarioService ambienteUsuarioService)
    {
        _ambienteUsuarioService = ambienteUsuarioService;
    }
    
    public async Task<RespostaBase<dynamic>> ExecuteAsync()
    {
        var usuarioLogado = await _ambienteUsuarioService.GetUsuarioAsync();
        
        throw new NotImplementedException();
    }
}