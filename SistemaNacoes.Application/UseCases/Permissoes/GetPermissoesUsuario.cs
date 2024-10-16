using SistemaNacoes.Application.Dtos.Permissoes;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Permissoes;

public class GetPermissoesUsuario
{
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly GetAllPermissoes _getAllPermissoes;

    public GetPermissoesUsuario(IAmbienteUsuarioService ambienteUsuarioService, GetAllPermissoes getAllPermissoes)
    {
        _ambienteUsuarioService = ambienteUsuarioService;
        _getAllPermissoes = getAllPermissoes;
    }
    
    public async Task<RespostaBase<List<GetPermissaoDto>>> ExecuteAsync()
    {
        var usuarioLogado = await _ambienteUsuarioService.RecuperaUsuarioAsync();
        var allPermissoes = _getAllPermissoes.Execute().Conteudo;

        var permissoes = allPermissoes.Select(x => new GetPermissaoDto
        {
            Identificador = x.Identificador,
            Nome = x.Nome,
            NomeFormatado = x.NomeFormatado,
            PossuiPermissao = usuarioLogado.Permissoes.HasFlag((EPermissoes)x.Identificador)
        }).ToList();

        var totalPermissoes = permissoes.Count;

        var respostaBase = new RespostaBase<List<GetPermissaoDto>>(
            RespostaBaseMensagem.GetUsuarioPermissoes, permissoes, totalPermissoes);

        return respostaBase;
    }
}