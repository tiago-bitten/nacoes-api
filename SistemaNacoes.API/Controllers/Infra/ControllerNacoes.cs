using Microsoft.AspNetCore.Mvc;
using SistemaNacoes.Shared.Resposta;
using SistemaNacoes.Shared.Paginacao;

namespace SistemaNacoes.API.Controllers.Infra;

[ApiController]
public class ControllerNacoes : ControllerBase
{
    private const string MensagemPadrao = "Ação executada com sucesso.";

    #region Métodos de Sucesso
    protected IActionResult RespostaSucesso<T>(T conteudo, string? mensagem = MensagemPadrao) where T : class
    {
        var resposta = RespostaBase<T>.SucessoComConteudo(conteudo, mensagem);
        return Ok(resposta);
    }

    protected IActionResult RespostaSucesso(string? mensagem = MensagemPadrao)
    {
        var resposta = RespostaBase<object>.SucessoBase(mensagem);
        return Ok(resposta);
    }

    #endregion

    #region Métodos de Erro
    protected IActionResult RespostaErro<T>(string mensagem) where T : class
    {
        var resposta = RespostaBase<T>.Erro(mensagem);
        return BadRequest(resposta);
    }

    #endregion

    #region Métodos de Listagem
    protected IActionResult RespostaPaginada<T>(PaginadoResult<T> paginadoResult, string? mensagem = MensagemPadrao) where T : class
    {
        var resposta = RespostaBase<List<T>>.ComPaginacao(
            paginadoResult.Dados,
            paginadoResult.Total,
            paginadoResult.TemProximo,
            paginadoResult.TemAnterior,
            mensagem
        );
        return Ok(resposta);
    }

    protected IActionResult RespostaListagemCompleta<T>(List<T> dados, string? mensagem = MensagemPadrao) where T : class
    {
        var resposta = RespostaBase<List<T>>.SucessoComConteudo(dados, mensagem);
        return Ok(resposta);
    }

    #endregion
}