namespace BMDb.Core.DTOs;

/// <summary>
/// DTO for registering a new user.
/// </summary>
public class RegisterRequest
{
    /// <summary>
    /// This property is used to define the Username property.
    /// </summary>
    [DataType(DataType.EmailAddress)]
    public required string Email { get; init; }
}