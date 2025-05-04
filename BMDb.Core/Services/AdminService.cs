namespace BMDb.Core.Services;

public class AdminService : IAdminService
{
    private readonly IMoviesRepository _moviesRepository;
    private readonly IMapper _mapper;

    public AdminService(IMoviesRepository moviesRepository, IMapper mapper)
    {
        _moviesRepository = moviesRepository;
        _mapper = mapper;
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
}