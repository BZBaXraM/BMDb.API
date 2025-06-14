using BMDb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BMDb.API.Controllers;

/// <summary>
/// Controller for managing user accounts, including logout functionality.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AuthContext _context;
    private readonly IBlackListService _blackListService;

    public AccountController(AuthContext context, IBlackListService blackListService)
    {
        _context = context;
        _blackListService = blackListService;
    }

    /// <summary>
    /// Logout a user
    /// </summary>
    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> LogoutAsync([FromBody] TokenDto dto)
    {
        _blackListService.AddTokenToBlackList(dto.AccessToken);
        var user = await _context.Users.FirstOrDefaultAsync(x => x.AccessCode == User.Identity!.Name);

        if (user != null)
        {
            user.RefreshToken = null;
            user.RefreshTokenExpireTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        return Ok("Logged out successfully");
    }
}