using System.ComponentModel.DataAnnotations;

namespace BMDb.API.DTOs;

/// <summary>
/// DTO for logging in a user.
/// </summary>
public class LoginRequestDto
{
    /// <summary>
    /// Email
    /// </summary>
    [DataType(DataType.EmailAddress)]
    public required string Email { get; init; } = string.Empty;

    /// <summary>
    /// Password
    /// </summary>
    [DataType(DataType.Password)]
    public required string Password { get; init; } = string.Empty;
}