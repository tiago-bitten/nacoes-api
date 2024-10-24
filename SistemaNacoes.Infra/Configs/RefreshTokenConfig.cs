﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Infra.Configs.Abstracoes;

namespace SistemaNacoes.Infra.Configs;

public class RefreshTokenConfig : EntidadeBaseConfig<RefreshToken>
{
    public override void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Token)
            .HasColumnType("text")
            .HasColumnName("token")
            .IsRequired();

        builder.Property(x => x.Principal)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("principal")
            .IsRequired();

        builder.Property(x => x.DataExpiracao)
            .HasColumnType("TIMESTAMP WITH TIME ZONE")
            .HasColumnName("data_expiracao")
            .IsRequired();
    }
}