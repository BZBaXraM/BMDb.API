using BMDb.Core.Extensions;

namespace BMDb.Core.Services;

public class AdminService : IAdminService
{
    private readonly IMoviesRepository _moviesRepository;

    public AdminService(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }

    public async Task<MovieResponse?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetByIdAsync(id, cancellationToken);

        return movie == null ? throw new ArgumentException($"Movie with id {id} not found") : movie.ToDto();
    }

    public async Task<MovieResponse> AddMovieAsync(AddMovieRequest request,
        CancellationToken cancellationToken = default)
    {
        var movie = request.ToEntity();

        _moviesRepository.Add(movie);

        await _moviesRepository.SaveChangesAsync(cancellationToken);

        return movie.ToDto();
    }

    public async Task<MovieResponse?> UpdateMovieAsync(UpdateMovieRequest request,
        CancellationToken cancellationToken = default)
    {
        if (!_moviesRepository.Exists(request.Id))
        {
            throw new ArgumentException($"Movie with id {request.Id} not found");
        }

        _moviesRepository.Update(request.ToUpdateDto());
        await _moviesRepository.SaveChangesAsync(cancellationToken);

        var updatedMovie = await _moviesRepository.GetByIdAsync(request.Id, cancellationToken);
        return updatedMovie?.ToDto();
    }

    public async Task<bool> DeleteMovieAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetByIdAsync(id, cancellationToken);
        if (movie == null)
        {
            throw new ArgumentException($"Movie with id {id} not found");
        }

        _moviesRepository.Delete(movie);
        await _moviesRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}