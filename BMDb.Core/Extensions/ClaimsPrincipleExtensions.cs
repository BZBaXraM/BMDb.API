namespace BMDb.Core.Extensions;

public static class ClaimsPrincipleExtensions
{
    public static string? GetUsername(this ClaimsPrincipal user)
        => user.FindFirst(ClaimTypes.Name)?.Value ?? user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    public static string? GetAccessCode(this ClaimsPrincipal user)
        => user.FindFirst("AccessCode")?.Value;
    
    /// <summary>
    /// Get the email from the claims principle
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static string? GetEmail(this ClaimsPrincipal user)
        => user.FindFirst(ClaimTypes.Email)?.Value;

    /// <summary>
    /// Get the user id from the claims principle 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static Guid GetUserId(this ClaimsPrincipal user)
        => Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
}