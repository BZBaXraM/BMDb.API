namespace BMDb.Core.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    private readonly IEmailService _emailService;

    public AuthService(IUserRepository userRepository, IJwtService jwtService, IEmailService emailService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _emailService = emailService;
    }

    public async Task<RegisterResponse> RegisterUserAsync(RegisterRequestDto registerRequestDto)
    {
        var accessCode = Guid.NewGuid().ToString()[..6];

        // Create a new user
        var user = new User
        {
            Email = registerRequestDto.Email,
            AccessCode = accessCode,
            RefreshToken = _jwtService.GenerateRefreshToken()
        };

        // Save the user to the database
        await _userRepository.AddUserAsync(user);

        // Send the access code to the user's email
        await _emailService.SendAccessCodeAsync(registerRequestDto.Email, accessCode);


        return new RegisterResponse
        {
            AccessToken = _jwtService.GenerateSecurityToken(user),
            RefreshToken = user.RefreshToken,
            AccessCode = accessCode
        };
    }

    public async Task<LoginResponseDto> LoginUserAsync(LoginRequestDto loginRequestDto)
    {
        var user = await _userRepository.GetAccessCodeAsync(loginRequestDto.AccessCode);
        if (user == null)
        {
            throw new Exception("Invalid access code");
        }

        return new LoginResponseDto
        {
            AccessCode = user.AccessCode,
            AccessToken = _jwtService.GenerateSecurityToken(user),
            RefreshToken = user.RefreshToken!
        };
    }

    public async Task<TokenDto> GetNewRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest)
    {
        var user = await _userRepository.GetUserByRefreshTokenAsync(refreshTokenRequest.RefreshToken);
        if (user == null)
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
}