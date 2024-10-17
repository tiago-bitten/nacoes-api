﻿using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces.Repositorios;
using SistemaNacoes.Infra.Contexts;

namespace SistemaNacoes.Infra.Repositorios;

public class PerfilAcessoRepository : RepositoryBase<PerfilAcesso>, IPerfilAcessoRepository
{
    public PerfilAcessoRepository(NacoesDbContext context) : base(context)
    {
    }
}