namespace BMDb.Core.ServiceContracts;

public interface IAuthService
{
    Task<AuthResponse?> RegisterUserAsync(RegisterRequest registerRequest);
    Task<AuthResponse?> LoginUserAsync(LoginRequest loginRequest);
    Task<TokenDto> GetNewRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest);
    Task ForgetAccessCodeAsync(ForgetAccessCodeRequestDto forgetAccessCodeRequestDto);
    Task LogoutAsync(string accessToken, string? userName);
}