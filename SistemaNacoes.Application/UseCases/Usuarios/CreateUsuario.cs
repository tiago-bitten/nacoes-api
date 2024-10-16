using AutoMapper;
using SistemaNacoes.Application.Dtos.Usuarios;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enterprise;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Enums;
using SistemaNacoes.Domain.Interfaces.Repositorios;

namespace SistemaNacoes.Application.UseCases.Usuarios;

public class CreateUsuario
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateUsuario(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<RespostaBase<GetUsuarioDto>> ExecuteAsync(CreateUsuarioDto dto)
    {
        var existsUsuario = await _uow.Usuarios.BuscarAsync(x => x.Email == dto.Email || x.Cpf == dto.Cpf);
        
        if (existsUsuario != null)
            throw new Exception(MensagemErroConstant.UsuarioJaCadastrado);
        
        var usuario = _mapper.Map<Usuario>(dto);
        usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword("123456");

        foreach (EPermissoes permissao in Enum.GetValues(typeof(EPermissoes)))
        {
            usuario.Permissoes |= permissao;
        }
        
        await _uow.Usuarios.AdicionarAsync(usuario);
        await _uow.CommitTransacaoAsync();
        
        var usuarioDto = _mapper.Map<GetUsuarioDto>(usuario);
        
        var respostaBase = new RespostaBase<GetUsuarioDto>(
            RespostaBaseMensagem.CreateUsuario, usuarioDto);
        
        return respostaBase;
    }
}