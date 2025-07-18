namespace BMDb.Infrastructure.Repositories;

public class MoviesRepository : IMoviesRepository
{
    private readonly MovieContext _context;

    public MoviesRepository(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<Movie>> GetMoviesAsync(string? filterOn, string? filterQuery, string? sortBy,
        bool isAscending = true, int pageNumber = 1,
        int pageSize = 100, string? title = null, string? genre = null, string? director = null, int? year = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Movies.AsQueryable();

        if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
        {
            query = filterOn.ToLower() switch
            {
                "title" => query.Where(m => m.Title.ToLower().Contains(filterQuery.ToLower())),
                "genre" => query.Where(m => m.Genres.Contains(filterQuery.ToLower())),
                "director" => query.Where(m => m.Director.ToLower().Contains(filterQuery.ToLower())),
                "year" => query.Where(m => m.Year.ToString().Contains(filterQuery.ToLower())),
                _ => query
            };
        }

        if (!string.IsNullOrEmpty(sortBy))
        {
            query = isAscending
                ? query.OrderBy(m => EF.Property<object>(m, sortBy))
                : query.OrderByDescending(m => EF.Property<object>(m, sortBy));
        }

        if (!string.IsNullOrEmpty(title))
        {
            query = query.Where(m => m.Title.ToLower().Contains(title.ToLower()));
        }

        if (!string.IsNullOrEmpty(genre))
        {
            query = query.Where(m => m.Genres.Any(g => g.ToLower() == genre.ToLower()));
        }

        if (!string.IsNullOrEmpty(director))
        {
            query = query.Where(m => m.Director.ToLower().Contains(director.ToLower()));
        }

        if (year.HasValue)
        {
            query = query.Where(m => m.Year == year.Value);
        }

        return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
    }

    public async Task<Movie?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await _context.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        return movie;
    }

    public async Task<Movie> AddMovieAsync(Movie movie, CancellationToken cancellationToken = default)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync(cancellationToken);

        return movie;
    }

    public async Task<Movie?> UpdateMovieAsync(Guid id, Movie movie, CancellationToken cancellationToken = default)
    {
        var existingMovie = await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        if (existingMovie == null)
        {
            return null;
        }

        existingMovie.Title = movie.Title;
        existingMovie.Poster = movie.Poster;
        existingMovie.Trailer = movie.Trailer;
        existingMovie.Year = movie.Year;
        existingMovie.Director = movie.Director;
        existingMovie.Genres = movie.Genres;
        existingMovie.Plot = movie.Plot;
        existingMovie.ImdbId = movie.ImdbId;

        await _context.SaveChangesAsync(cancellationToken);

        return existingMovie;
    }

    public async Task<Movie> DeleteMovieAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

        if (movie == null)
        {
            throw new KeyNotFoundException($"Movie with id {id} not found.");
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync(cancellationToken);

        return movie;
    }

    public async Task<List<Movie>> GetMovieByImdbIdAsync(string imdbId, CancellationToken cancellationToken = default)
    {
        var movies = await _context.Movies
            .AsNoTracking()
            .Where(m => EF.Functions.Like(m.ImdbId, $"%{imdbId}%"))
            .ToListAsync(cancellationToken);

        return movies;
    }

    public async Task<List<Movie>> GetRandomMoviesAsync(int limit = 10, CancellationToken cancellationToken = default)
    {
        var movies = await _context.Movies
            .OrderBy(m => Guid.NewGuid())
            .Take(limit)
            .ToListAsync(cancellationToken);

        return movies;
    }
}