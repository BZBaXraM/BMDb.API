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

    public async Task<ResponseModel<List<MovieResponse>>> GetMoviesAsync(MoviesQueryResponse response,
        CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetMoviesAsync(
            response.FilterOn, response.FilterQuery, response.SortBy, response.IsAscending ?? true,
            response.PageNumber, response.PageSize, response.Title, response.Genre, response.Director, response.Year,
            cancellationToken);

        return ResponseModel.Success(movies.Select(x => x.ToDto()).ToList());
    }


    public async Task<ResponseModel<MovieResponse>> GetMovieByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetByIdAsync(id, cancellationToken);

        return movie == null
            ? ResponseModel.Failure<MovieResponse>($"Movie with id {id} not found", 404)
            : ResponseModel.Success(movie.ToDto());
    }

    public async Task<ResponseModel<IEnumerable<MovieResponse>>> GetMovieByImdbIdAsync(string imdbId,
        CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetMovieByImdbIdAsync(imdbId, cancellationToken);
        return ResponseModel.Success(movies.Select(x => x.ToDto()));
    }

    public async Task<ResponseModel<IEnumerable<MovieResponse>>> GetRandomMoviesAsync(int limit = 10,
        CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetRandomMoviesAsync(limit, cancellationToken);
        return ResponseModel.Success(movies.Select(x => x.ToDto()));
    }
}