using SistemaNacoes.Application.Dtos.Permissoes;
using SistemaNacoes.Application.Responses;
using SistemaNacoes.Domain.Enums;

namespace SistemaNacoes.Application.UseCases.Permissoes
{
    public class GetAllPermissoes
    {
        private static readonly Dictionary<EPermissoes, string> PermissaoDisplayNames = new()
        {
            // Agenda
            { EPermissoes.OPEN_AGENDA, "Abrir agenda" },
            { EPermissoes.CLOSE_AGENDA, "Fechar agenda" },
            { EPermissoes.FINALIZE_AGENDA, "Finalizar agenda" },
            { EPermissoes.GET_AGENDA, "Visualizar agenda" },
            { EPermissoes.UPDATE_AGENDA, "Atualizar agenda" },
            
            // Agendamento
            { EPermissoes.CREATE_AGENDAMENTO, "Criar agendamento" },
            { EPermissoes.DELETE_AGENDAMENTO, "Deletar agendamento" },
            { EPermissoes.DELETE_AGENDAMENTO_ATIVIDADE, "Deletar atividade do agendamento" },
            { EPermissoes.GET_AGENDAMENTO, "Visualizar agendamento" },
            { EPermissoes.VINCULATE_AGENDAMENTO_ATIVIDADE, "Vincular atividade ao agendamento" },
            
            // Atividade
            { EPermissoes.CREATE_ATIVIDADE, "Criar atividade" },
            { EPermissoes.DELETE_ATIVIDADE, "Deletar atividade" },
            { EPermissoes.GET_ATIVIDADE, "Visualizar atividade" },
            { EPermissoes.UPDATE_ATIVIDADE, "Atualizar atividade" },
            
            // Voluntario
            { EPermissoes.CREATE_VOLUNTARIO, "Criar voluntário" },
            { EPermissoes.DELETE_VOLUNTARIO, "Deletar voluntário" },
            { EPermissoes.GET_VOLUNTARIO, "Visualizar voluntário" },
            { EPermissoes.UPDATE_VOLUNTARIO, "Atualizar voluntário" },
            
            // Ministerio
            { EPermissoes.CREATE_MINISTERIO, "Criar ministério" },
            { EPermissoes.DELETE_MINISTERIO, "Deletar ministério" },
            { EPermissoes.GET_MINISTERIO, "Visualizar ministério" },
            { EPermissoes.UPDATE_MINISTERIO, "Atualizar ministério" },
            
            // VoluntarioMinisterio
            { EPermissoes.CREATE_VOLUNTARIO_MINISTERIO, "Vincular voluntário ao ministério" },
            { EPermissoes.DELETE_VOLUNTARIO_MINISTERIO, "Desvincular voluntário do ministério" },
            { EPermissoes.GET_VOLUNTARIO_MINISTERIO, "Visualizar vínculo de voluntário ao ministério" },
            
            // Usuario 
            { EPermissoes.CREATE_USUARIO, "Criar usuário" },
            { EPermissoes.DELETE_USUARIO, "Deletar usuário" },
            { EPermissoes.GET_USUARIO, "Visualizar usuário" },
            { EPermissoes.UPDATE_USUARIO, "Atualizar usuário" },
            
            // UsuarioMinisterio
            { EPermissoes.CREATE_USUARIO_MINISTERIO, "Vincular usuário ao ministério" },
            { EPermissoes.DELETE_USUARIO_MINISTERIO, "Desvincular usuário do ministério" },
            { EPermissoes.GET_USUARIO_MINISTERIO, "Visualizar vínculo de usuário ao ministério" },
            
            // Grupo
            { EPermissoes.CREATE_GRUPO, "Criar grupo" },
            { EPermissoes.DELETE_GRUPO, "Deletar grupo" },
            { EPermissoes.GET_GRUPO, "Visualizar grupo" },
            { EPermissoes.UPDATE_GRUPO, "Atualizar grupo" },
            
            // GrupoVoluntario
            { EPermissoes.CREATE_GRUPO_VOLUNTARIO, "Vincular voluntário ao grupo" },
            { EPermissoes.DELETE_GRUPO_VOLUNTARIO, "Desvincular voluntário do grupo" },
            { EPermissoes.GET_GRUPO_VOLUNTARIO, "Visualizar vínculo de voluntário ao grupo" },
            
            // DataIndisponivel
            { EPermissoes.CREATE_DATA_INDISPONIVEL, "Criar data indisponível" },
            { EPermissoes.DELETE_DATA_INDISPONIVEL, "Deletar data indisponível" },
            { EPermissoes.GET_DATA_INDISPONIVEL, "Visualizar data indisponível" },
            { EPermissoes.SUSPEND_DATA_INDISPONIVEL, "Suspender data indisponível" },
            { EPermissoes.UPDATE_DATA_INDISPONIVEL, "Atualizar data indisponível" },
            
            // Escala
            { EPermissoes.CREATE_ESCALA, "Criar escala" },
        };

        public RespostaBase<List<GetPermissaoDto>> Execute()
        {
            var permissoes = (from EPermissoes permissao in Enum.GetValues(typeof(EPermissoes))
                where permissao != EPermissoes.None
                select new GetPermissaoDto
                {
                    Identificador = (long)permissao,
                    Nome = permissao.ToString(),
                    NomeFormatado = PermissaoDisplayNames.TryGetValue(permissao, out var displayName)
                        ? displayName
                        : permissao.ToString()
                }).ToList();

            var totalPermissoes = permissoes.Count;
            
            var respostaBase = new RespostaBase<List<GetPermissaoDto>>(
                MensagemRepostasConstant.GetPermissoes, permissoes, totalPermissoes);

            return respostaBase;
        }
    }
}
