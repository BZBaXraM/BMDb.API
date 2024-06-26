using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMDb.API.Auth;

/// <summary>
/// This class is used to define the CanTestRequirement class.
/// </summary>
public class CanTestRequirement : IAuthorizationRequirement, IAuthorizationHandler
{
    /// <inheritdoc />
    [HttpGet]
    public Task HandleAsync(AuthorizationHandlerContext context)
    {
        var claim = context.User.Claims.FirstOrDefault(x => x.Type == "permissions");
        if (claim is not null)
        {
            var permissions = JsonSerializer.Deserialize<string[]>(claim.Value);
            if (permissions != null && permissions.Contains("CanTest"))
            {
                context.Succeed(this);
            }
            else
            {
                context.Fail();
            }
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}