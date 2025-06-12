namespace BMDb.Infrastructure.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
    }

    public virtual DbSet<Movie> Movies => Set<Movie>();
}