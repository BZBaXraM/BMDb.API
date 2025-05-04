namespace BMDb.Core.ServiceContracts;

public interface IAdminService
{
    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MovieResponse?> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to add a movie.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MovieResponse> AddMovieAsync(AddMovieRequestDto request, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to update a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MovieResponse?> UpdateMovieAsync(Guid id, UpdateMovieRequestDto request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to delete a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DeleteMovieAsync(Guid id, CancellationToken cancellationToken = default);
}