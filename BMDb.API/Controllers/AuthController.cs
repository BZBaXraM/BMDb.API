using BMDb.Core.DTOs;
using BMDb.Core.ServiceContracts;
using BMDb.Domain.Entities;
using BMDb.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
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
    private readonly IAuthService _service;

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
    public async Task<ActionResult<LoginResponseDto>> Register([FromBody] RegisterRequestDto request)
    {
        var user = new User
        {
            Email = request.Email,
            AccessCode = Guid.NewGuid().ToString().Substring(0, 6),
            RefreshToken = Guid.NewGuid().ToString()
        };

        await _service.RegisterUserAsync(request);

        return Ok("Check your email for the access code.");
    }

    /// <summary>
    /// Login a user.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("login-with-access-code")]
    public async Task<ActionResult<LoginResponseDto>> LoginWithAccessCode([FromBody] LoginRequestDto request)
    {
        var user = await _service.LoginUserAsync(request);

        return Ok(user);
    }
}