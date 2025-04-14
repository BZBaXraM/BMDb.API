namespace BMDb.Core.DTOs;

/// <summary>
/// DTO for logging in a user.
/// </summary>
public class LoginRequestDto
{
    public required string AccessCode { get; set; }
}