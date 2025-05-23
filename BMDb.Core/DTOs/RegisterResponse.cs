namespace BMDb.Core.DTOs;

public class RegisterResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public string AccessCode { get; set; } = string.Empty;
}