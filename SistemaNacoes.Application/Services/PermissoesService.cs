using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Services;
using SistemaNacoes.Shared.Extensions;

namespace SistemaNacoes.Application.Services;

public class PermissoesService : IPermissoesService
{

    private readonly IAmbienteUsuarioService _ambienteService;
    
    public PermissoesService(IAmbienteUsuarioService ambienteService)
    {
        _ambienteService = ambienteService;
    }
        
    public List<EPermissoes> RecuperarTodos()
    {
        return Enum.GetValues<EPermissoes>().ToList();
    }

    public async Task VerificaGarantePermissaoAsync(EPermissoes permissao, string mensagemErro = "Você não possui permissão")
    {
        var usuario = await _ambienteService.RecuperaUsuarioAsync("PerfilAcesso");
        
        if (!usuario.PossuiPermissao(permissao))
            throw new NacoesAppException(mensagemErro);
    }
}