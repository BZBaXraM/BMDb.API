namespace BMDb.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IMoviesService, MoviesService>();
        services.AddSingleton<IBlackListService, BlackListService>();

        services.Configure<EmailConfig>(configuration.GetSection("EmailConfig"));

        services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        services.AddSingleton<RegisterRequestValidator>();
        services.AddSingleton<LoginRequestValidator>();

        return services;
    }
}