using AutoMapper;
using SistemaNacoes.Application.DTOs;
using SistemaNacoes.Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace SistemaNacoes.Application.UseCases.Usuarios
{
    public class BuscarUsuarioPorId
    {
        private readonly IUsuarioMinisterioRepository _usuarioMinisterioRepository;
        private readonly IMapper _mapper;

        public BuscarUsuarioPorId(IUsuarioMinisterioRepository usuarioMinisterioRepository,
            IMapper mapper)
        {
            _usuarioMinisterioRepository = usuarioMinisterioRepository;
            _mapper = mapper;
        }

        public async Task<LerUsuarioDTO> ExecuteAsync(int id)
        {
            var usuario = await _usuarioMinisterioRepository.GetByIdAsync(id);

            return usuario != null ? _mapper.Map<LerUsuarioDTO>(usuario) : throw new Exception("Usuário não encontrado.");
        }
    }
}
