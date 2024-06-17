using AutoMapper;
using SistemaNacoes.Application.DTOs;
using SistemaNacoes.Domain.Interfaces;

namespace SistemaNacoes.Application.UseCases.Usuarios
{
    public class ObterUsuarioPorId
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public ObterUsuarioPorId(IUsuarioRepository usuarioRepository,
            IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<LerUsuarioDTO> ExecuteAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            return usuario != null ? _mapper.Map<LerUsuarioDTO>(usuario) : throw new Exception("Usuário não encontrado.");
        }
    }
}
