namespace BMDb.Core.ServiceContracts;

/// <summary>
/// This interface is used to define the contract for the AsyncMovieService class.
/// </summary>
public interface IMoviesService
{
    /// <summary>
    /// This method is used to get all movies.
    /// </summary>
    /// <returns> </returns>
    Task<List<MovieResponse>> GetMoviesAsync(string? filterOn, string? filterQuery,
        string? sortBy, bool isAscending = true, int pageNumber = 1, int pageSize = 100,
        CancellationToken cancellationToken = default);


    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MovieResponse?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// This method is used to get a movie by title.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<MovieResponse>> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to get a movie by year.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<MovieResponse>> GetMovieByYearAsync(string year, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to get a movie by a director.
    /// </summary>
    /// <param name="director"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<MovieResponse>> GetMovieByDirectorAsync(string director,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to get a movie by genre.
    /// </summary>
    /// <param name="genre"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    // Task<IEnumerable<MovieResponse>> GetMovieByGenreAsync(string genre, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to get a movie by imdb id.
    /// </summary>
    /// <param name="imdbId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<MovieResponse>>
        GetMovieByImdbIdAsync(string imdbId, CancellationToken cancellationToken = default);
}