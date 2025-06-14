namespace BMDb.API.Middlewares;

/// <inheritdoc />
public class BlackListMiddleware : IMiddleware
{
    private readonly IBlackListService _blackListService;

    /// <summary>
    /// Middleware to check if a token is blacklisted.
    /// </summary>
    /// <param name="blackListService"></param>
    public BlackListMiddleware(IBlackListService blackListService)
    {
        _blackListService = blackListService;
    }

    /// <summary>
    /// Invokes the middleware to check if the token is blacklisted.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string? token = context.Request.Headers.Authorization;

        token = token?.Replace("Bearer ", "");


        if (!string.IsNullOrWhiteSpace(token) && _blackListService.IsTokenBlackListed(token))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Token is blacklisted.");
            return;
        }

        await next(context);
    }
}