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
    public async Task<ActionResult<ResponseModel<AuthResponse>>> RegisterAsync([FromBody] RegisterRequest request)
    {
        var response = await _service.RegisterUserAsync(request);

        return StatusCode(response.StatusCode, response);
    }

    /// <summary>
    /// Login a user.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<ActionResult<ResponseModel<AuthResponse>>> LoginAsync([FromBody] LoginRequest request)
    {
        var response = await _service.LoginUserAsync(request);

        return StatusCode(response.StatusCode, response);
    }

    /// <summary>
    /// Refresh the access token using the refresh token.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("refresh-token")]
    public async Task<ActionResult<ResponseModel<TokenResponse>>> GetRefreshTokenAsync([FromBody] RefreshTokenRequest request)
    {
        var response = await _service.GetNewRefreshTokenAsync(request);

        return StatusCode(response.StatusCode, response);
    }

    /// <summary>
    /// Forgets the access code for a user, allowing them to reset it.  
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("forget-access-code")]
    public async Task<ActionResult<ResponseModel>> ForgetAccessCodeAsync([FromBody] ForgetAccessCodeRequest request)
    {
        var response = await _service.ForgetAccessCodeAsync(request);
        return StatusCode(response.StatusCode, response);
    }

    /// <summary>
    /// Logs out the user by invalidating their access token and clearing their refresh token.
    /// </summary>
    /// <param name="response"/>
    /// <returns></returns>
    [HttpPost("logout")]
    [Authorize]
    public async Task<ActionResult<ResponseModel>> LogoutAsync([FromBody] TokenResponse response)
    {
        var responseModel = await _service.LogoutAsync(response.AccessToken, User.Identity?.Name);
        return StatusCode(responseModel.StatusCode, response);
    }
}