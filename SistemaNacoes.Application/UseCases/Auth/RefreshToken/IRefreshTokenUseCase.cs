using SistemaNacoes.Application.UseCases.Auth.RefreshToken.Dtos;

namespace SistemaNacoes.Application.UseCases.Auth.RefreshToken;

public interface IRefreshTokenUseCase : ICommandUseCaseBase<RefreshTokenResult, RefreshTokenRequest>
{
    
}