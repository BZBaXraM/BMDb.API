namespace BMDb.Infrastructure.Data;

/// <inheritdoc />
public class AuthContext : DbContext
{
    /// <inheritdoc />
    public AuthContext(DbContextOptions<AuthContext> options) : base(options)
    {
    }

    /// <summary>
    /// Users DbSet
    /// </summary>
    public virtual DbSet<User> Users => Set<User>();
}