using System.Security.Claims;

namespace BMDb.API.Services;

/// <summary>
/// Interface for token service.
/// </summary>
public interface IJwtService
{
    /// <summary>
    /// Creates a token for a user.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="email"></param>
    /// <param name="roles"></param>
    /// <param name="userClaims"></param>
    /// <returns></returns>
    string GenerateSecurityToken(
        string id,
        string email,
        IEnumerable<string> roles,
        IEnumerable<Claim> userClaims);
}