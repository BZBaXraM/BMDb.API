namespace BMDb.Infrastructure.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MovieContext>();

        await context.Database.MigrateAsync();
        await SeedAsync(context);
    }

    private static async Task SeedAsync(MovieContext context)
    {
        await SeedProductAsync(context);
    }

    private static async Task SeedProductAsync(MovieContext context)
    {
        if (!await context.Movies.AnyAsync())
        {
            await context.Movies.AddRangeAsync(InitData.Movies);
            await context.SaveChangesAsync();
        }
    }
}