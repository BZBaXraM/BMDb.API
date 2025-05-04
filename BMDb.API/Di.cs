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
            .WriteTo.File("/Logs/BMDb_Log.txt", rollingInterval: RollingInterval.Day)
            .MinimumLevel.Information()
            .CreateLogger();


        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddCors();
        
        services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "BMDb.API",
                Version = "v1"
            });
            var path = Path.Combine(AppContext.BaseDirectory, "BahramMVMovieAPI.xml");
            setup.IncludeXmlComments(path);

            setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
            });

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    []
                }
            });
        });

        return services;
    }
}