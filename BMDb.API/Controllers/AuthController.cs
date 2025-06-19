namespace BMDb.API.Controllers;

/// <summary>
/// Controller for handling authentication requests.
/// </summary>
// [ServiceFilter(typeof(LogUserActivity))]
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
    public async Task<ActionResult<AuthResponse>> RegisterAsync([FromBody] RegisterRequest request)
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
    public async Task<ActionResult<AuthResponse>> LoginAsync([FromBody] LoginRequest request)
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
    public async Task<ActionResult<TokenDto>> GetRefreshTokenAsync([FromBody] RefreshTokenRequest request)
    {
        var token = await _service.GetNewRefreshTokenAsync(request);

        return Ok(token);
    }

    /// <summary>
    /// Forgets the access code for a user, allowing them to reset it.  
    /// </summary>
    /// <param name="forgetAccessCodeRequestDto"></param>
    /// <returns></returns>
    [HttpPost("forget-access-code")]
    public async Task<IActionResult> ForgetAccessCodeAsync([FromBody] ForgetAccessCodeRequestDto forgetAccessCodeRequestDto)
    {
        await _service.ForgetAccessCodeAsync(forgetAccessCodeRequestDto);
        return Ok("Access code forgotten successfully");
    }

    /// <summary>
    /// Logs out the user by invalidating their access token and clearing their refresh token.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> LogoutAsync([FromBody] TokenDto dto)
    {
        await _service.LogoutAsync(dto.AccessToken, User.Identity?.Name);
        return Ok("Logged out successfully");
    }
}