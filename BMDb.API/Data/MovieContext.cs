using BMDb.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BMDb.API.Data;

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