using System.Text;
using BMDb.API.Auth;
using BMDb.API.DTOs.Validation;
using BMDb.API.Entities;
using BMDb.API.Mappings;
using BMDb.API.Models;
using BMDb.API.Providers;
using BMDb.API.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
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
                            Id = "Bearer",
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        services.AddDbContext<MovieContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddDbContext<AuthContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("IdentityConnection"));
        });

        services.AddScoped<IAsyncMovieService, MovieService>();
        services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        return services;
    }

    /// <summary>
    /// AuthenticationAndAuthorization method.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AuthenticationAndAuthorization(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IRequestUserProvider, RequestUserProvider>();
        services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<AuthContext>();
        services.AddScoped<ITokenService, TokenService>();

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
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret))
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("CanTest", policy =>
            {
                policy.RequireAuthenticatedUser();
                // policy.RequireClaim("CanTest");
                policy.Requirements.Add(new CanTestRequirement());
            });
        });

        return services;
    }
}