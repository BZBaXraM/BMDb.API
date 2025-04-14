namespace BMDb.Core.DTOs;

public class TokenDto
{
    /// <summary>
    /// Access token for the user.
    /// </summary>
    public string? AccessToken { get; set; }

    /// <summary>
    /// Refresh token for the user.
    /// </summary>
    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpireTime { get; set; }
}