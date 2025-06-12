namespace BMDb.API.Controllers;

/// <summary>
/// Controller for handling authentication requests.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    /// <summary>
    /// Constructor for the AuthController.
    /// </summary>
    /// <param name="service"></param>
    public AuthController(IAuthService service)
    {
        _service = service;
    }

    /// <summary>
    /// Register a user.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
    {
        var user = await _service.RegisterUserAsync(request);

        if (user is null) return NotFound();

        return Ok("Check your email for the access code.");
    }

    /// <summary>
    /// Login a user.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> LoginWithAccessCode([FromBody] LoginRequest request)
    {
        var user = await _service.LoginUserAsync(request);

        if (user is null) return Unauthorized();

        return Ok(user);
    }

    /// <summary>
    /// Refresh the access token using the refresh token.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("refresh-token")]
    public async Task<ActionResult<TokenDto>> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var user = await _service.GetNewRefreshTokenAsync(request);

        return Ok(user);
    }

    /// <summary>
    /// Logout a user by invalidating their tokens.
    /// </summary>
    /// <returns></returns>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] TokenDto dto)
    {
        // TODO: Implement logout logic
    }
}