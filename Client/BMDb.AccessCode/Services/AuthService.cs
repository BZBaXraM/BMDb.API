using System.Net.Http.Json;
using BMDb.AccessCode.Models;

namespace BMDb.AccessCode.Services;

public class AuthService(HttpClient client) : IAuthService
{
    public async Task<string?> RegisterUserAsync(RegisterRequestModel request)
    {
        var response = await client.PostAsJsonAsync("auth/register", request);

        return await ReadMessageAsync(response);
    }

    public async Task<string?> ForgetAccessCodeAsync(ForgetAccessCodeRequestModel request)
    {
        var response = await client.PostAsJsonAsync("auth/forget-access-code", request);

        return await ReadMessageAsync(response);
    }

    private static async Task<string?> ReadMessageAsync(HttpResponseMessage response)
    {
        var result = await response.Content.ReadFromJsonAsync<ResponseModel>();

        if (response.IsSuccessStatusCode)
        {
            return result?.Message;
        }

        return result?.Errors is { Count: > 0 } errors
            ? string.Join("; ", errors)
            : result?.Message;
    }
}