using System.Text.Json.Serialization;

namespace SistemaNacoes.Application.Dtos.Agendas
{
    public class CloseAgendaDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
    }
}
