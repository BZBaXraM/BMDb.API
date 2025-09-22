namespace BMDb.Core.RepositoryContracts;

public interface IMoviesRepository
{
    Task<List<Movie>> GetMoviesAsync(string? filterOn, string? filterQuery,
        string? sortBy, bool isAscending = true, int pageNumber = 1, int pageSize = 100,
        string? title = null, string? genre = null,
        string? director = null, int? year = null,
        CancellationToken cancellationToken = default);
    bool Exists(Guid id);
    
    Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Movie movie);
    void Update(Movie movie);
    void Delete(Movie movie);
    Task<List<Movie>> GetMovieByImdbIdAsync(string imdbId, CancellationToken cancellationToken = default);
    Task<List<Movie>> GetRandomMoviesAsync(int limit = 10, CancellationToken cancellationToken = default);
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}