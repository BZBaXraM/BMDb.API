namespace BMDb.Core.ServiceContracts;

public interface IAdminService
{
    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ResponseModel<MovieResponse>> GetMovieByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to add a movie.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ResponseModel<MovieResponse>> AddMovieAsync(AddMovieRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to update a movie.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ResponseModel<MovieResponse>> UpdateMovieAsync(Guid id, UpdateMovieRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// This method is used to delete a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ResponseModel> DeleteMovieAsync(Guid id, CancellationToken cancellationToken = default);
}