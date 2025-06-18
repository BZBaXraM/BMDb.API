using BMDb.AccessCode.Models;

namespace BMDb.AccessCode.Services;

public interface IAuthService
{
    Task <string?> RegisterUserAsync(RegisterRequestModel request);
}