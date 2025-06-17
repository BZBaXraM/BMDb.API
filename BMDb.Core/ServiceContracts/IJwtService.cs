namespace BMDb.Core.ServiceContracts;

/// <summary>
/// Interface for token service.
/// </summary>
public interface IJwtService
{
    /// <summary>
    /// Generate a security token
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    string GenerateSecurityToken(User user);

    /// <summary>
    /// Generate a refresh token
    /// </summary>
    /// <returns></returns>
    string GenerateRefreshToken();
}