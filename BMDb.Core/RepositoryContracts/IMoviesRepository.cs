namespace BMDb.Core.RepositoryContracts;

public interface IMoviesRepository
{
    Task<List<Movie>> GetMoviesAsync(string? filterOn, string? filterQuery,
        string? sortBy, bool isAscending = true, int pageNumber = 1, int pageSize = 100,
        string? title = null, string? genre = null,
        string? director = null, int? year = null,
        CancellationToken cancellationToken = default);

    Task<Movie?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Movie> AddMovieAsync(Movie movie, CancellationToken cancellationToken = default);
    Task<Movie?> UpdateMovieAsync(Guid id, Movie movie, CancellationToken cancellationToken = default);
    Task<Movie> DeleteMovieAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Movie>> GetMovieByImdbIdAsync(string imdbId, CancellationToken cancellationToken = default);
    Task<List<Movie>> GetRandomMoviesAsync(int limit = 10, CancellationToken cancellationToken = default);
}