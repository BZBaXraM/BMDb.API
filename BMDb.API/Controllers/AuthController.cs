using BMDb.API.DTOs;
using BMDb.API.Models;
using BMDb.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BMDb.API.Controllers;

/// <summary>
/// Controller for handling authentication requests.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IJwtService _service;

    /// <summary>
    /// Register a new user.
    /// </summary>
    /// <param name="userManager"></param>
    /// <param name="signInManager"></param>
    /// <param name="roleManager"></param>
    /// <param name="service"></param>
    public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        RoleManager<IdentityRole> roleManager, IJwtService service)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _service = service;
    }

    /// <summary>
    /// Register a user.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<ActionResult<LoginResponseDto>> Register([FromBody] RegisterRequestDto request)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser is not null)
        {
            return Conflict("User with same email already exists");
        }

        var user = new AppUser
        {
            UserName = request.Email,
            Email = request.Email,
            RefreshToken = Guid.NewGuid().ToString("N").ToLower()
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return await GenerateToken(user);
    }

    /// <summary>
    /// Login a user.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Unauthorized();
        }

        var canSignIn = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!canSignIn.Succeeded)
        {
            return Unauthorized();
        }

        var role = await _userManager.GetRolesAsync(user);
        var userClaims = await _userManager.GetClaimsAsync(user);

        var accessToken = _service.GenerateSecurityToken(user.Id, user.UserName!, role, userClaims);
        var refreshToken = Guid.NewGuid().ToString("N").ToLower();
        user.RefreshToken = refreshToken;
        await _userManager.UpdateAsync(user);

        return new LoginResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    /// <summary>
    /// Refresh token - get new access token using refresh token
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("refresh")]
    public async Task<ActionResult<LoginResponseDto>> Refresh(
        [FromBody] RefreshTokenRequest request)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);
        if (user is null)
        {
            return Unauthorized();
        }

        return await GenerateToken(user);
    }


    private async Task<LoginResponseDto> GenerateToken(AppUser user)
    {
        var role = await _userManager.GetRolesAsync(user);
        var userClaims = await _userManager.GetClaimsAsync(user);

        var accessToken = _service.GenerateSecurityToken(user.Id, user.UserName!,
            role, userClaims);
        var refreshToken = user.RefreshToken;

        await _userManager.UpdateAsync(user);

        return new LoginResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken!
        };
    }
}