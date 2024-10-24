﻿using SistemaNacoes.Domain.Entidades.Abstracoes;

namespace SistemaNacoes.Domain.Entidades;

public sealed class Voluntario : Pessoa
{
    public Voluntario() {}
        
    public Guid ChaveAcesso { get; set; } = Guid.NewGuid();

    public List<GrupoVoluntario> GrupoVoluntarios { get; set; } = new();

    public List<VoluntarioMinisterio> VoluntarioMinisterios { get; set; } = new();
    public List<Agendamento> Agendamentos { get; set; } = new();
    public List<DataIndisponivel> DataIndisponiveis { get; set; } = new();
    public List<EscalaItem> EscalaItens { get; set; } = new();
}