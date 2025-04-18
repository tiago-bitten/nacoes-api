﻿using SistemaNacoes.Domain.Entidades.Infra;

namespace SistemaNacoes.Domain.Entidades.UsuarioMinisterio
{
    public sealed class UsuarioMinisterio : EntidadeBase
    {
        public UsuarioMinisterio() {}
        
        public UsuarioMinisterio(Usuario.Usuario usuario, Ministerio.Ministerio ministerio)
        {
            Usuario = usuario;
            Ministerio = ministerio;
        }
        
        public int UsuarioId { get; set; }
        public int MinisterioId { get; set; }

        public Usuario.Usuario Usuario { get; set; }
        public Ministerio.Ministerio Ministerio { get; set; }
    }
}
