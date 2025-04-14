namespace BMDb.Core.DTOs;

/// <summary>
///    DTO for the LoginResponse
/// </summary>
public class LoginResponseDto
{
    public string AccessCode { get; set; } = string.Empty;

    /// <summary>
    ///   AccessToken
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    ///  RefreshToken
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;
}