namespace BMDb.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string AccessCode { get; set; }
    public DateTime RefreshTokenExpireTime { get; set; }
    public string Role { get; set; } = "User";
    public string? RefreshToken { get; set; }
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}