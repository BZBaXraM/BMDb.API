namespace BMDb.Core.ServiceContracts;

public interface IAuthService
{
    Task<RegisterResponse> RegisterUserAsync(RegisterRequestDto registerRequestDto);
    Task<LoginResponseDto> LoginUserAsync(LoginRequestDto loginRequestDto);
    Task<TokenDto> GetNewRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest);
}