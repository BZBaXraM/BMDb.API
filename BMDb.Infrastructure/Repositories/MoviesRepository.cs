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
        int pageSize = 100, CancellationToken cancellationToken = default)
    {
        var query = _context.Movies.AsQueryable();

        if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
        {
            query = filterOn.ToLower() switch
            {
                "title" => query.Where(m => m.Title.ToLower().Contains(filterQuery.ToLower())),
                "genre" => query.Where(m => m.Genre.ToLower().Contains(filterQuery.ToLower())),
                "director" => query.Where(m => m.Director.ToLower().Contains(filterQuery.ToLower())),
                "year" => query.Where(m => m.Year.ToString().Contains(filterQuery)),
                _ => query
            };
        }

        if (!string.IsNullOrEmpty(sortBy))
        {
            query = isAscending
                ? query.OrderBy(m => EF.Property<object>(m, sortBy))
                : query.OrderByDescending(m => EF.Property<object>(m, sortBy));
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
        await _context.Movies.AddAsync(movie, cancellationToken);
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
        existingMovie.Genre = movie.Genre;
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

    public async Task<List<Movie>> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        var movies = await _context.Movies
            .AsNoTracking()
            .Where(m => EF.Functions.Like(m.Title, $"%{title}%"))
            .ToListAsync(cancellationToken);

        return movies;
    }

    public async Task<List<Movie>> GetMovieByGenreAsync(string genre, CancellationToken cancellationToken = default)
    {
        var movies = await _context.Movies
            .AsNoTracking()
            .Where(m => EF.Functions.Like(m.Genre, $"%{genre}%"))
            .ToListAsync(cancellationToken);

        return movies;
    }

    public async Task<List<Movie>> GetMovieByDirectorAsync(string director,
        CancellationToken cancellationToken = default)
    {
        var movies = await _context.Movies
            .AsNoTracking()
            .Where(m => EF.Functions.Like(m.Director, $"%{director}%"))
            .ToListAsync(cancellationToken);

        return movies;
    }

    public async Task<List<Movie>> GetMovieByYearAsync(string year, CancellationToken cancellationToken = default)
    {
        var movies = await _context.Movies
            .AsNoTracking()
            .Where(m => EF.Functions.Like(m.Year, $"%{year}%"))
            .ToListAsync(cancellationToken);

        return movies;
    }

    public async Task<List<Movie>> GetMovieByImdbIdAsync(string imdbId, CancellationToken cancellationToken = default)
    {
        var movies = await _context.Movies
            .AsNoTracking()
            .Where(m => EF.Functions.Like(m.ImdbId, $"%{imdbId}%"))
            .ToListAsync(cancellationToken);

        return movies;
    }
}