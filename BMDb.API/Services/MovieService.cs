using BMDb.API.Data;
using BMDb.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BMDb.API.Services;

/// <summary>
/// This class is used to implement the IMovieService interface.
/// </summary>
public class MovieService : IMovieService
{
    private readonly MovieContext _context;

    /// <summary>
    /// This constructor is used to inject the MovieContext class.
    /// </summary>
    /// <param name="context"></param>
    public MovieService(MovieContext context)
        => _context = context;

    /// <summary>
    /// This method is used to get all movies.
    /// </summary>
    /// <returns></returns>
    public async Task<List<Movie>> GetMoviesAsync(string? filterOn, string? filterQuery,
        string? sortBy, bool isAscending = true, int pageNumber = 1, int pageSize = 100,
        CancellationToken cancellationToken = default)
    {
        switch (string.IsNullOrWhiteSpace(filterOn))
        {
            case false when string.IsNullOrWhiteSpace(filterQuery) == false:
            {
                switch (filterOn)
                {
                    case "title":
                        return await _context.Movies.Where(x => x.Title.Contains(filterQuery)).AsNoTracking()
                            .ToListAsync(cancellationToken);
                    case "year":
                        return await _context.Movies.Where(x => x.Year.Contains(filterQuery)).AsNoTracking()
                            .ToListAsync(cancellationToken);
                    case "director":
                        return await _context.Movies.Where(x => x.Director.Contains(filterQuery)).AsNoTracking()
                            .ToListAsync(cancellationToken);
                    case "genre":
                        return await _context.Movies.Where(x => x.Genre.Contains(filterQuery)).AsNoTracking()
                            .ToListAsync(cancellationToken);
                }

                break;
            }
        }

        switch (string.IsNullOrWhiteSpace(sortBy))
        {
            case false:
            {
                switch (sortBy)
                {
                    case "title":
                        return isAscending
                            ? await _context.Movies.OrderBy(x => x.Title).AsNoTracking().ToListAsync(cancellationToken)
                            : await _context.Movies.OrderByDescending(x => x.Title).AsNoTracking()
                                .ToListAsync(cancellationToken);
                    case "year":
                        return isAscending
                            ? await _context.Movies.OrderBy(x => x.Year).AsNoTracking().ToListAsync(cancellationToken)
                            : await _context.Movies.OrderByDescending(x => x.Year).AsNoTracking()
                                .ToListAsync(cancellationToken);
                    case "director":
                        return isAscending
                            ? await _context.Movies.OrderBy(x => x.Director).AsNoTracking()
                                .ToListAsync(cancellationToken)
                            : await _context.Movies.OrderByDescending(x => x.Director).AsNoTracking()
                                .ToListAsync(cancellationToken);
                    case "genre":
                        return isAscending
                            ? await _context.Movies.OrderBy(x => x.Genre).AsNoTracking().ToListAsync(cancellationToken)
                            : await _context.Movies.OrderByDescending(x => x.Genre).AsNoTracking()
                                .ToListAsync(cancellationToken);
                }

                break;
            }
        }

        var skip = (pageNumber - 1) * pageSize;
        return await _context.Movies.Skip(skip).Take(pageSize).AsNoTracking().ToListAsync(cancellationToken);
    }

    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Movie?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await _context.Movies.FindAsync(id, cancellationToken);
        if (item is null) return null!;

        return new Movie
        {
            Id = item.Id,
            Title = item.Title,
            Year = item.Year,
            Director = item.Director,
            Genre = item.Genre,
            Plot = item.Plot,
            Poster = item.Poster,
            Trailer = item.Trailer,
            ImdbId = item.ImdbId
        };
    }

    /// <summary>
    /// This method is used to add a movie.
    /// </summary>
    /// <param name="movie"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Movie> AddMovieAsync(Movie movie, CancellationToken cancellationToken = default)
    {
        await _context.Movies.AddAsync(movie, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return movie;
    }

    /// <summary>
    /// This method is used to update a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="movie"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Movie?> UpdateMovieAsync(Guid id, Movie movie, CancellationToken cancellationToken = default)
    {
        var update = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
        if (update is null)
        {
            return null;
        }

        update.Title = movie.Title;
        update.Year = movie.Year;
        movie.Director = movie.Director;
        update.Genre = movie.Genre;
        update.Plot = movie.Plot;
        update.Poster = movie.Poster;
        update.Trailer = movie.Trailer;
        update.ImdbId = movie.ImdbId;

        await _context.SaveChangesAsync(cancellationToken);
        return movie;
    }

    /// <summary>
    /// This method is used to delete a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Movie> DeleteMovieAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await _context.Movies.FindAsync(new object?[] { id, cancellationToken },
            cancellationToken: cancellationToken);
        if (item is null) return null!;

        _context.Movies.Remove(item);
        await _context.SaveChangesAsync(cancellationToken);

        return item;
    }

    /// <summary>
    /// This method is used to get a movie by title.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Movie>> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default)
        => await _context.Movies.Where(x => x.Title.Contains(title)).AsNoTracking().ToListAsync(cancellationToken);


    /// <summary>
    /// This method is used to get a movie by year.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Movie>> GetMovieByYearAsync(string year,
        CancellationToken cancellationToken = default)
        => await _context.Movies.Where(x => x.Year == year).AsNoTracking().ToListAsync(cancellationToken);


    /// <summary>
    /// This method is used to get a movie by director.
    /// </summary>
    /// <param name="director"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Movie>> GetMovieByDirectorAsync(string director,
        CancellationToken cancellationToken = default)
        => await _context.Movies.Where(x => x.Director == director).AsNoTracking().ToListAsync(cancellationToken);


    /// <summary>
    /// This method is used to get a movie by genre.
    /// </summary>
    /// <param name="genre"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Movie>> GetMovieByGenreAsync(string genre,
        CancellationToken cancellationToken = default)
        => await _context.Movies.Where(x => x.Genre == genre).AsNoTracking().ToListAsync(cancellationToken);


    /// <summary>
    /// This method is used to get a movie by imdb id.
    /// </summary>
    /// <param name="imdbId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Movie>> GetMovieByImdbIdAsync(string imdbId,
        CancellationToken cancellationToken = default)
        => await _context.Movies.Where(x => x.ImdbId == imdbId).AsNoTracking().ToListAsync(cancellationToken);
}