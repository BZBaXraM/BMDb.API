using Microsoft.EntityFrameworkCore.Design;

namespace BMDb.Infrastructure.Data;

public class AuthContextFactory : IDesignTimeDbContextFactory<AuthContext>
{
    public AuthContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AuthContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AuthDb;Username=postgres;Password=root");

        return new AuthContext(optionsBuilder.Options);
    }
}