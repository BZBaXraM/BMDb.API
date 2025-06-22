namespace BMDb.Core.DTOs;

public class AuthResponse
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; } 
    public DateTime RefreshTokenExpireTime { get; set; }
}