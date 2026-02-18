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

    public async Task<MovieResponse?> UpdateMovieAsync(Guid id, UpdateMovieRequest request,
        CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetByIdAsync(id, cancellationToken);

        if (movie == null)
        {
            throw new ArgumentException($"Movie with id {id} not found");
        }

        movie.Title = request.Title ?? movie.Title;
        movie.Poster = request.Poster ?? movie.Poster;
        movie.Trailer = request.Trailer ?? movie.Trailer;
        movie.Year = request.Year ?? movie.Year;
        movie.Director = request.Director ?? movie.Director;
        movie.Genres = request.Genres ?? movie.Genres;
        movie.Plot = request.Plot ?? movie.Plot;
        movie.ImdbId = request.ImdbId ?? movie.ImdbId;

        _moviesRepository.Update(movie);
        await _moviesRepository.SaveChangesAsync(cancellationToken);

        var updatedMovie = await _moviesRepository.GetByIdAsync(id, cancellationToken);
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