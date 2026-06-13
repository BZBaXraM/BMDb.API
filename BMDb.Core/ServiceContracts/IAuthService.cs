namespace BMDb.Core.ServiceContracts;

public interface IAuthService
{
    Task<ResponseModel<AuthResponse>> RegisterUserAsync(RegisterRequest registerRequest);
    Task<ResponseModel<AuthResponse>> LoginUserAsync(LoginRequest loginRequest);
    Task<ResponseModel<TokenResponse>> GetNewRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest);
    Task<ResponseModel> ForgetAccessCodeAsync(ForgetAccessCodeRequest forgetAccessCodeRequest);
    Task<ResponseModel> LogoutAsync(string accessToken, string? userName);
}