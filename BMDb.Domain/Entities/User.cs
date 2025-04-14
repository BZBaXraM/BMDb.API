namespace BMDb.Domain.Entities;

/// <summary>
/// This class is used to define the AppUser class.
/// </summary>
public class User
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string AccessCode { get; set; }
    public DateTime RefreshTokenExpireTime { get; set; }
    public string Role { get; set; } = "User";

    /// <summary>
    /// This property is used to define the RefreshToken property.
    /// </summary>
    public string? RefreshToken { get; set; }

    /// <summary>
    /// Movie collection.
    /// </summary>
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}