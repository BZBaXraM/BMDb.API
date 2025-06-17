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

    public async Task<AuthResponse?> RegisterUserAsync(RegisterRequest registerRequest)
    {
        var accessCode = Guid.NewGuid().ToString()[..6];

        var validationResult = await _registerRequestValidator.ValidateAsync(registerRequest);

        if (!validationResult.IsValid)
        {
            throw new Exception("Invalid registration request");
        }

        var user = new User
        {
            Email = registerRequest.Email,
            AccessCode = accessCode,
            RefreshToken = _jwtService.GenerateRefreshToken()
        };

        await _userRepository.AddUserAsync(user);

        await _emailService.SendAccessCodeAsync(registerRequest.Email, accessCode);


        return new AuthResponse
        {
            AccessToken = _jwtService.GenerateSecurityToken(user),
            RefreshToken = user.RefreshToken,
            AccessCode = accessCode
        };
    }

    public async Task<AuthResponse?> LoginUserAsync(LoginRequest loginRequest)
    {
        var user = await _userRepository.GetAccessCodeAsync(loginRequest.AccessCode);

        if (user is null)
        {
            throw new Exception("Invalid access code");
        }

        var validationResult = await _loginRequestValidator.ValidateAsync(loginRequest);

        if (!validationResult.IsValid)
        {
            throw new Exception("Invalid login request");
        }

        return new AuthResponse
        {
            AccessCode = user.AccessCode,
            AccessToken = _jwtService.GenerateSecurityToken(user),
            RefreshToken = user.RefreshToken!
        };
    }

    public async Task<TokenDto> GetNewRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest)
    {
        var user = await _userRepository.GetUserByRefreshTokenAsync(refreshTokenRequest.RefreshToken!);

        if (user is null)
        {
            throw new Exception("Invalid refresh token");
        }

        user.RefreshToken = _jwtService.GenerateRefreshToken();

        return new TokenDto
        {
            AccessToken = _jwtService.GenerateSecurityToken(user),
            RefreshToken = user.RefreshToken,
            RefreshTokenExpireTime = user.RefreshTokenExpireTime
        };
    }

    public async Task LogoutAsync(string accessToken, string? userName)
    {
        _blackListService.AddTokenToBlackList(accessToken);
        var user = await _userRepository.GetUserDataAsync(accessToken, userName);

        if (user != null)
        {
            user.RefreshToken = null;
            user.RefreshTokenExpireTime = DateTime.UtcNow;
            await _userRepository.SaveUserAsync();
        }
    }
}