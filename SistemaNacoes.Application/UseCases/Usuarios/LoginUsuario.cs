using SistemaNacoes.Application.DTOs;
using SistemaNacoes.Application.Interfaces;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace SistemaNacoes.Application.UseCases.Usuarios
{
    public class LoginUsuario
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public LoginUsuario(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<TokenDTO?> ExecuteAsync(LoginDTO dto)
        {
            var usuario = await _usuarioRepository.AutenticarAsync(dto.Email, dto.Senha) ?? throw new Exception("Usuário ou senha inválidos.");
            var token = _tokenService.GerarToken(usuario);

            return new TokenDTO { Token = token };
        }
    }
}
