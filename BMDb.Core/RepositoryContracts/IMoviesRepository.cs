namespace BMDb.Core.RepositoryContracts;

public interface IMoviesRepository
{
    Task<List<Movie>> GetMoviesAsync(string? filterOn, string? filterQuery,
        string? sortBy, bool isAscending = true, int pageNumber = 1, int pageSize = 100,
        CancellationToken cancellationToken = default);
    Task<Movie?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Movie> AddMovieAsync(Movie movie, CancellationToken cancellationToken = default);
    Task<Movie?> UpdateMovieAsync(Guid id, Movie movie, CancellationToken cancellationToken = default);
    Task<Movie> DeleteMovieAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Movie>> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<List<Movie>> GetMovieByGenreAsync(string genre, CancellationToken cancellationToken = default);
    Task<List<Movie>> GetMovieByDirectorAsync(string director, CancellationToken cancellationToken = default);
    Task<List<Movie>> GetMovieByYearAsync(string year, CancellationToken cancellationToken = default);
    Task<List<Movie>> GetMovieByImdbIdAsync(string imdbId, CancellationToken cancellationToken = default);
}