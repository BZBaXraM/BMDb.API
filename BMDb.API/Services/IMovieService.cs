using BMDb.API.Models;

namespace BMDb.API.Services;

/// <summary>
/// This interface is used to define the contract for the AsyncMovieService class.
/// </summary>
public interface IMovieService
{
    /// <summary>
    /// This method is used to get all movies.
    /// </summary>
    /// <returns> </returns>
    Task<List<Movie>> GetMoviesAsync(string? filterOn, string? filterQuery,
        string? sortBy, bool isAscending = true, int pageNumber = 1, int pageSize = 100,
        CancellationToken cancellationToken = default);


    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Movie?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to add a movie.
    /// </summary>
    /// <param name="movie"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Movie> AddMovieAsync(Movie movie, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to update a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="movie"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Movie?> UpdateMovieAsync(Guid id, Movie movie, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to delete a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Movie> DeleteMovieAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to get a movie by title.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Movie>> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to get a movie by year.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Movie>> GetMovieByYearAsync(string year, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to get a movie by director.
    /// </summary>
    /// <param name="director"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Movie>> GetMovieByDirectorAsync(string director, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to get a movie by genre.
    /// </summary>
    /// <param name="genre"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Movie>> GetMovieByGenreAsync(string genre, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to get a movie by imdb id.
    /// </summary>
    /// <param name="imdbId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Movie>> GetMovieByImdbIdAsync(string imdbId, CancellationToken cancellationToken = default);
}