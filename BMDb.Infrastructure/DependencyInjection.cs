namespace BMDb.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMoviesRepository, MoviesRepository>();

        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IJwtService, JwtService>();

        services.AddDbContext<MovieContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        // services.AddDbContext<AuthContext>(options =>
        // {
        //     options.UseNpgsql(configuration.GetConnectionString("IdentityConnection"));
        // });

        JwtConfig jwtConfig = new();
        configuration.GetSection("JWT").Bind(jwtConfig);
        services.AddSingleton(jwtConfig);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        services.AddHttpContextAccessor();

        services.AddAuthorizationBuilder()
            .AddPolicy("Admin", policy =>
                policy.RequireAssertion(context =>
                    context.User.HasClaim(c => c is { Type: "Role", Value: "Admin" })))
            .AddPolicy("User", policy =>
                policy.RequireAssertion(context =>
                    context.User.HasClaim(c => c is { Type: "Role", Value: "User" })));

        return services;
    }
}