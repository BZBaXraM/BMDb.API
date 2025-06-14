namespace BMDb.Core.DTOs;

public class TokenDto
{
    public string AccessToken { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public DateTime RefreshTokenExpireTime { get; set; }
}