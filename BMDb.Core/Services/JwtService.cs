using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace BMDb.Core.Services;

/// <summary>
/// The JWT service
/// </summary>
public class JwtService : IJwtService
{
    private readonly JwtConfig _jwtConfig;

    public JwtService(JwtConfig jwtConfig)
    {
        _jwtConfig = jwtConfig;
    }

    /// <summary>
    /// The JWT service configuration
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public string GenerateSecurityToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Role", user.Role)
            ]),
            Expires = DateTime.UtcNow.AddHours(_jwtConfig.Expiration),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };

        if (!string.IsNullOrEmpty(_jwtConfig.Issuer))
        {
            tokenDescriptor.Issuer = _jwtConfig.Issuer;
        }

        if (!string.IsNullOrEmpty(_jwtConfig.Audience))
        {
            tokenDescriptor.Audience = _jwtConfig.Audience;
        }

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }
}