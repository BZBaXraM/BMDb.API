namespace BMDb.Infrastructure.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MovieContext>();
        var authContext = scope.ServiceProvider.GetRequiredService<AuthContext>();

        await context.Database.MigrateAsync();
        await authContext.Database.MigrateAsync();
        await SeedAsync(context, authContext);
    }

    private static async Task SeedAsync(MovieContext context, AuthContext authContext)
    {
        await SeedMoviesAsync(context);
        await SeedAuthAsync(authContext);
    }

    private static async Task SeedMoviesAsync(MovieContext context)
    {
        if (!await context.Movies.AnyAsync())
        {
            await context.Movies.AddRangeAsync(InitData.Movies);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedAuthAsync(AuthContext context)
    {
        if (!await context.Users.AnyAsync())
        {
            await context.Database.ExecuteSqlRawAsync("DELETE FROM  \"Users\"");
            await context.SaveChangesAsync();
        }
    }
}