namespace BMDb.API.DTOs;

/// <summary>
///    DTO for the LoginResponse
/// </summary>
public class LoginResponseDto
{
    /// <summary>
    ///   AccessToken
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    ///  RefreshToken
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;
}