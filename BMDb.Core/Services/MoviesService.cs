namespace BMDb.Core.Services;

/// <summary>
/// This class is used to implement the IMoviesService interface.
/// </summary>
public class MoviesService : IMoviesService
{
    private readonly IMoviesRepository _moviesRepository;
    private readonly IMapper _mapper;

    public MoviesService(IMoviesRepository moviesRepository, IMapper mapper)
    {
        _moviesRepository = moviesRepository;
        _mapper = mapper;
    }

    public async Task<List<MovieResponse>> GetMoviesAsync(string? filterOn, string? filterQuery, string? sortBy,
        bool isAscending = true, int pageNumber = 1,
        int pageSize = 100, CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetMoviesAsync(filterOn, filterQuery, sortBy, isAscending, pageNumber,
            pageSize, cancellationToken);
        return _mapper.Map<List<MovieResponse>>(movies);
    }

    public async Task<MovieResponse?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetMovieByIdAsync(id, cancellationToken);
        return movie == null ? null : _mapper.Map<MovieResponse>(movie);
    }

    public async Task<MovieResponse> AddMovieAsync(AddMovieRequestDto request,
        CancellationToken cancellationToken = default)
    {
        var movie = _mapper.Map<Movie>(request);

        var addedMovie = await _moviesRepository.AddMovieAsync(movie, cancellationToken);

        return _mapper.Map<MovieResponse>(addedMovie);
    }

    public async Task<MovieResponse?> UpdateMovieAsync(Guid id, UpdateMovieRequestDto request,
        CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetMovieByIdAsync(id, cancellationToken);
        if (movie == null)
        {
            return null;
        }

        _mapper.Map(request, movie);

        var updatedMovie = await _moviesRepository.UpdateMovieAsync(id, movie, cancellationToken);

        return updatedMovie == null ? null : _mapper.Map<MovieResponse>(updatedMovie);
    }

    public async Task<bool> DeleteMovieAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetMovieByIdAsync(id, cancellationToken);
        if (movie == null)
        {
            return false;
        }

        await _moviesRepository.DeleteMovieAsync(id, cancellationToken);

        return true;
    }

    public async Task<List<MovieResponse>> GetMovieByTitleAsync(string title,
        CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetMovieByTitleAsync(title, cancellationToken);
        return _mapper.Map<List<MovieResponse>>(movies);
    }

    public async Task<IEnumerable<MovieResponse>> GetMovieByYearAsync(string year,
        CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetMovieByYearAsync(year, cancellationToken);
        return _mapper.Map<List<MovieResponse>>(movies);
    }

    public async Task<IEnumerable<MovieResponse>> GetMovieByDirectorAsync(string director,
        CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetMovieByDirectorAsync(director, cancellationToken);
        return _mapper.Map<List<MovieResponse>>(movies);
    }

    public async Task<IEnumerable<MovieResponse>> GetMovieByGenreAsync(string genre,
        CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetMovieByGenreAsync(genre, cancellationToken);
        return _mapper.Map<List<MovieResponse>>(movies);
    }

    public async Task<IEnumerable<MovieResponse>> GetMovieByImdbIdAsync(string imdbId,
        CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetMovieByImdbIdAsync(imdbId, cancellationToken);
        return _mapper.Map<List<MovieResponse>>(movies);
    }
}