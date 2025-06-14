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
    Task<List<MovieResponse>> GetMoviesAsync(MoviesQueryDto dto,
        CancellationToken cancellationToken = default);


    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MovieResponse?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to get a movie by imdb id.
    /// </summary>
    /// <param name="imdbId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<MovieResponse>>
        GetMovieByImdbIdAsync(string imdbId, CancellationToken cancellationToken = default);

    Task<IEnumerable<MovieResponse>>
        GetRandomMoviesAsync(int limit = 10, CancellationToken cancellationToken = default);
}