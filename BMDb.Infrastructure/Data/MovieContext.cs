namespace BMDb.Infrastructure.Data;

/// <inheritdoc />
public class MovieContext : DbContext
{
    /// <inheritdoc />
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
    }

    /// <summary>
    /// Movies DbSet
    /// </summary>
    public virtual DbSet<Movie> Movies => Set<Movie>();
}