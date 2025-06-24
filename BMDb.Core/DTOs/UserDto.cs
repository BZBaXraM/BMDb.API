namespace BMDb.Core.DTOs;

public class UserDto
{
    public required string Email { get; set; }
    public required string AccessCode { get; set; }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpireTime { get; set; }
}