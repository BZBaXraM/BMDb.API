using BMDb.Core.Extensions;

namespace BMDb.Core.Services;

public class AdminService : IAdminService
{
    private readonly IMoviesRepository _moviesRepository;

    public AdminService(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }

    public async Task<ResponseModel<MovieResponse>> GetMovieByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetByIdAsync(id, cancellationToken);

        return movie == null
            ? ResponseModel.Failure<MovieResponse>($"Movie with id {id} not found", 404)
            : ResponseModel.Success(movie.ToDto());
    }

    public async Task<ResponseModel<MovieResponse>> AddMovieAsync(AddMovieRequest request,
        CancellationToken cancellationToken = default)
    {
        var movie = request.ToEntity();

        _moviesRepository.Add(movie);

        await _moviesRepository.SaveChangesAsync(cancellationToken);

        return new ResponseModel<MovieResponse>(movie.ToDto(), true, "Movie created", 201);
    }

    public async Task<ResponseModel<MovieResponse>> UpdateMovieAsync(Guid id, UpdateMovieRequest request,
        CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetByIdAsync(id, cancellationToken);

        if (movie == null)
        {
            return ResponseModel.Failure<MovieResponse>($"Movie with id {id} not found", 404);
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
        return ResponseModel.Success(updatedMovie!.ToDto(), "Movie updated");
    }

    public async Task<ResponseModel> DeleteMovieAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetByIdAsync(id, cancellationToken);
        if (movie == null)
        {
            return ResponseModel.Failure($"Movie with id {id} not found", 404);
        }

        _moviesRepository.Delete(movie);
        await _moviesRepository.SaveChangesAsync(cancellationToken);

        return ResponseModel.Success("Movie deleted");
    }
}