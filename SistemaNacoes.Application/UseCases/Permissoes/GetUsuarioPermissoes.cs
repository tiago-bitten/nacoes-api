using SistemaNacoes.Application.Dtos.Permissoes;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Services;

namespace SistemaNacoes.Application.UseCases.Permissoes;

public class GetUsuarioPermissoes
{
    private readonly IAmbienteUsuarioService _ambienteUsuarioService;
    private readonly GetAllPermissoes _getAllPermissoes;

    public GetUsuarioPermissoes(IAmbienteUsuarioService ambienteUsuarioService, GetAllPermissoes getAllPermissoes)
    {
        _ambienteUsuarioService = ambienteUsuarioService;
        _getAllPermissoes = getAllPermissoes;
    }
    
    public async Task<RespostaBase<List<GetPermissaoDto>>> ExecuteAsync()
    {
        var usuarioLogado = await _ambienteUsuarioService.GetUsuarioAsync();
        var allPermissoes = _getAllPermissoes.Execute().Conteudo;

        var permissoes = allPermissoes.Select(p => new GetPermissaoDto
        {
            Identificador = p.Identificador,
            Nome = p.Nome,
            NomeFormatado = p.NomeFormatado,
            PossuiPermissao = usuarioLogado.Permissoes.HasFlag((EPermissoes)p.Identificador)
        }).ToList();

        var totalPermissoes = permissoes.Count;

        var respostaBase = new RespostaBase<List<GetPermissaoDto>>(
            MensagemRepostasConstant.GetUsuarioPermissoes, permissoes, totalPermissoes);

        return respostaBase;
    }
}