using Microsoft.OpenApi;

namespace BMDb.API;

/// <summary>
/// Di - Dependency Injection class.
/// </summary>
public static class Di
{
    /// <summary>
    /// AddRepositories method.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        var builder = WebApplication.CreateBuilder();

        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("/Logs/BMDb.txt", rollingInterval: RollingInterval.Day)
            .MinimumLevel.Information()
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddCors();

        services.AddSingleton<BlackListMiddleware>();

        services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "BMDb.API",
                Version = "v1"
            });
            var path = Path.Combine(AppContext.BaseDirectory, "BahramMVMovieAPI.xml");
            setup.IncludeXmlComments(path);

            setup.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token. Example: Bearer {token}",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                }
            );

            setup.AddSecurityRequirement(document =>
                new OpenApiSecurityRequirement { [new OpenApiSecuritySchemeReference("Bearer", document)] = [] });
        });

        return services;
    }
}