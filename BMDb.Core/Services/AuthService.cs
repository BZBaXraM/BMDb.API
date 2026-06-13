namespace BMDb.Core.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    private readonly IEmailService _emailService;
    private readonly IBlackListService _blackListService;
    private readonly RegisterRequestValidator _registerRequestValidator;
    private readonly LoginRequestValidator _loginRequestValidator;

    public AuthService(IUserRepository userRepository, IJwtService jwtService, IEmailService emailService,
        RegisterRequestValidator registerRequestValidator, LoginRequestValidator loginRequestValidator,
        IBlackListService blackListService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _emailService = emailService;
        _registerRequestValidator = registerRequestValidator;
        _loginRequestValidator = loginRequestValidator;
        _blackListService = blackListService;
    }

    public async Task<ResponseModel<AuthResponse>> RegisterUserAsync(RegisterRequest registerRequest)
    {
        var accessCode = GenerateAccessCode();

        var validationResult = await _registerRequestValidator.ValidateAsync(registerRequest);

        if (!validationResult.IsValid)
        {
            return ResponseModel.Failure<AuthResponse>("Invalid registration request", 400,
                validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }

        var existingUser = await _userRepository.GetUserByEmailAsync(registerRequest.Email);

        if (existingUser != null)
        {
            return ResponseModel.Failure<AuthResponse>("User with this email already exists", 409);
        }

        User user = new()
        {
            Email = registerRequest.Email,
            AccessCode = accessCode,
            RefreshToken = _jwtService.GenerateRefreshToken()
        };

        await _userRepository.AddUserAsync(user);

        await _emailService.SendAccessCodeAsync(registerRequest.Email, accessCode);

        var authResponse = new AuthResponse
        {
            AccessToken = _jwtService.GenerateSecurityToken(user),
            RefreshToken = user.RefreshToken,
        };

        return ResponseModel.Success(authResponse, "Check your email for the access code.");
    }

    public async Task<ResponseModel<AuthResponse>> LoginUserAsync(LoginRequest loginRequest)
    {
        var user = await _userRepository.GetAccessCodeAsync(loginRequest.AccessCode);

        if (user is null)
        {
            return ResponseModel.Failure<AuthResponse>("Invalid access code", 401);
        }

        var validationResult = await _loginRequestValidator.ValidateAsync(loginRequest);

        if (!validationResult.IsValid)
        {
            return ResponseModel.Failure<AuthResponse>("Invalid login request", 400,
                validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }

        user.RefreshToken = _jwtService.GenerateRefreshToken();
        user.RefreshTokenExpireTime = DateTime.UtcNow.AddDays(7);

        await _userRepository.SaveUserAsync();

        var authResponse = new AuthResponse
        {
            AccessToken = _jwtService.GenerateSecurityToken(user),
            RefreshToken = user.RefreshToken,
            RefreshTokenExpireTime = user.RefreshTokenExpireTime
        };

        return ResponseModel.Success(authResponse, "Login successful");
    }

    public async Task<ResponseModel<TokenResponse>> GetNewRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest)
    {
        var user = await _userRepository.GetUserByRefreshTokenAsync(refreshTokenRequest.RefreshToken!);

        if (user is null)
        {
            return ResponseModel.Failure<TokenResponse>("Invalid refresh token", 401);
        }

        if (user.RefreshTokenExpireTime < DateTime.UtcNow)
        {
            user.RefreshToken = null;
            await _userRepository.SaveUserAsync();
            return ResponseModel.Failure<TokenResponse>("Refresh token has expired", 401);
        }

        user.RefreshToken = _jwtService.GenerateRefreshToken();
        user.RefreshTokenExpireTime = DateTime.UtcNow.AddDays(7);

        await _userRepository.SaveUserAsync();

        var tokenDto = new TokenResponse
        {
            AccessToken = _jwtService.GenerateSecurityToken(user),
            RefreshToken = user.RefreshToken,
            RefreshTokenExpireTime = user.RefreshTokenExpireTime
        };

        return ResponseModel.Success(tokenDto);
    }

    public async Task<ResponseModel> ForgetAccessCodeAsync(ForgetAccessCodeRequest forgetAccessCodeRequest)
    {
        var user = await _userRepository.GetUserByEmailAsync(forgetAccessCodeRequest.Email);

        if (user is null)
        {
            return ResponseModel.Failure("User not found", 404);
        }

        var accessCode = GenerateAccessCode();
        user.AccessCode = accessCode;

        await _userRepository.SaveUserAsync();
        await _emailService.SendAccessCodeAsync(user.Email, accessCode);

        return ResponseModel.Success("Check your email for the new access code.");
    }

    public async Task<ResponseModel> LogoutAsync(string accessToken, string? userName)
    {
        _blackListService.AddTokenToBlackList(accessToken);
        var user = await _userRepository.GetUserDataAsync(accessToken, userName);

        if (user != null)
        {
            user.RefreshToken = null;
            user.RefreshTokenExpireTime = DateTime.UtcNow;
            await _userRepository.SaveUserAsync();
        }

        return ResponseModel.Success("Logged out successfully");
    }

    private static string GenerateAccessCode()
    {
        return Guid.NewGuid().ToString()[..6];
    }
}