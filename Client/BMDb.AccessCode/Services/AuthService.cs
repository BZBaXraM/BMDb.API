using System.Net.Http.Json;
using BMDb.AccessCode.Models;

namespace BMDb.AccessCode.Services;

public class AuthService(HttpClient client) : IAuthService
{
    public async Task<string?> RegisterUserAsync(RegisterRequestModel request)
    {
        var response = await client.PostAsJsonAsync("auth/register", request);

        if (response.IsSuccessStatusCode)
        {
            return "Check your email for the access code.";
        }

        return null; // Or handle error accordingly
    }

    public async Task<string?> ForgetAccessCodeAsync(ForgetAccessCodeRequestModel request)
    {
        var response = await client.PostAsJsonAsync("auth/forget-access-code", request);

        if (response.IsSuccessStatusCode)
        {
            return "Check your email for the new access code.";
        }

        return null; // Or handle error accordingly
    }
}