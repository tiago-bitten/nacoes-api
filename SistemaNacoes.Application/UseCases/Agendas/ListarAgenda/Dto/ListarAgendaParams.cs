using SistemaNacoes.Application.Dtos;

namespace SistemaNacoes.Application.UseCases.Agendas.ListarAgenda.Dto;

public class ListarAgendaParams : Param
{
    public int Mes { get; set; }
    public int Ano { get; set; }
}