using BMDb.Core.Extensions;

namespace BMDb.Core.Services;

/// <summary>
/// This class is used to implement the IMoviesService interface.
/// </summary>
public class MoviesService : IMoviesService
{
    private readonly IMoviesRepository _moviesRepository;

    public MoviesService(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }

    public async Task<List<MovieResponse>> GetMoviesAsync(MoviesQueryDto dto,
        CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetMoviesAsync(
            dto.FilterOn, dto.FilterQuery, dto.SortBy, dto.IsAscending ?? true,
            dto.PageNumber, dto.PageSize, dto.Title, dto.Genre, dto.Director, dto.Year,
            cancellationToken);

        return movies.Select(x => x.ToDto()).ToList();
    }


    public async Task<MovieResponse?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetByIdAsync(id, cancellationToken);
        return movie?.ToDto();
    }

    public async Task<IEnumerable<MovieResponse>> GetMovieByImdbIdAsync(string imdbId,
        CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetMovieByImdbIdAsync(imdbId, cancellationToken);
        return movies.Select(x => x.ToDto()).ToList();
    }

    public async Task<IEnumerable<MovieResponse>> GetRandomMoviesAsync(int limit = 10,
        CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetRandomMoviesAsync(limit, cancellationToken);
        return movies.Select(x => x.ToDto()).ToList();
    }
}