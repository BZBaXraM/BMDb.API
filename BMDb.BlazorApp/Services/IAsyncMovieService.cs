using BMDb.BlazorApp.Models;

namespace BMDb.BlazorApp.Services;

public interface IAsyncMovieService
{
    Task<List<MovieModel>> GetMoviesAsync();
    Task<List<MovieModel>> SearchMoviesAsync(string? search);
    Task<int> GetTotalCountAsync();
    Task<List<MovieModel>> GetMoviesDetailsAsync(Guid id);
}