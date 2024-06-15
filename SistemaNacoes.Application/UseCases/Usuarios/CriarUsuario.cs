using SistemaNacoes.Application.DTOs;
using SistemaNacoes.Domain.Interfaces;
using AutoMapper;
using SistemaNacoes.Domain.Entidades;

namespace SistemaNacoes.Application.UseCases.Usuarios
{
    public class CriarUsuario
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public CriarUsuario(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<LerUsuarioDTO> ExecuteAsync(CriarUsuarioDTO dto)
        {
            var usuarioExistente = await _usuarioRepository.GetByEmailAsync(dto.Email);

            if (usuarioExistente != null)
            {
                throw new Exception("Já existe um usuário com este e-mail.");
            }

            var usuario = _mapper.Map<Usuario>(dto);

            var usuarioCriado = await _usuarioRepository.CreateAsync(usuario);

            return _mapper.Map<LerUsuarioDTO>(usuarioCriado);
        }
    }
}
