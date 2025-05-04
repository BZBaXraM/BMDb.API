namespace BMDb.API.Controllers;

/// <summary>
/// This class is used to define the MoviesController class.
/// </summary>
[Authorize("User")]
[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMoviesService _service;

    /// <summary>
    /// This constructor is used to inject the MovieContext class.
    /// </summary>
    /// <param name="service"></param>
    public MoviesController(IMoviesService service)
    {
        _service = service;
    }

    /// <summary>
    /// This method is used to get all movies.
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-all")]
    public async Task<IActionResult> GetMoviesAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
        [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100, CancellationToken cancellationToken = default)
    {
        var movies = await _service.GetMoviesAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber,
            pageSize, cancellationToken);
        return Ok(movies);
    }


    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("get-by-id/{id:guid}")]
    public async Task<IActionResult> GetMovieById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await _service.GetMovieByIdAsync(id, cancellationToken);
        if (movie is null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    /// <summary>
    /// This method is used to get a movie by title.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("title/{title}")]
    public async Task<IActionResult> GetMovieByTitleAsync(string title,
        CancellationToken cancellationToken = default)
    {
        var movies = await _service.GetMovieByTitleAsync(title, cancellationToken);

        return Ok(movies);
    }


    /// <summary>
    /// This method is used to get a movie by year.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("year/{year}")]
    public async Task<IActionResult> GetMovieByYearAsync(string year, CancellationToken cancellationToken = default)
    {
        var movies = await _service.GetMovieByYearAsync(year, cancellationToken);

        return Ok(movies);
    }

    /// <summary>
    /// This method is used to get a movie by a director.
    /// </summary>
    /// <param name="director"></param>
    /// <returns></returns>
    [HttpGet("director/{director}")]
    public async Task<IActionResult> GetMovieByDirectorAsync(string director)
    {
        var movies = await _service.GetMovieByDirectorAsync(director);

        return Ok(movies);
    }

    /// <summary>
    /// This method is used to get a movie by genre.
    /// </summary>
    /// <param name="genre"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("genre/{genre}")]
    public async Task<IActionResult> GetMovieByGenreAsync(string genre,
        CancellationToken cancellationToken = default)
    {
        var movies = await _service.GetMovieByGenreAsync(genre, cancellationToken);

        return Ok(movies);
    }

    /// <summary>
    /// This method is used to get a movie by imdb id.
    /// </summary>
    /// <param name="imdb"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("imdb/{imdb}")]
    public async Task<IActionResult> GetMovieByImdbIdAsync(string imdb,
        CancellationToken cancellationToken = default)
    {
        var movies = await _service.GetMovieByImdbIdAsync(imdb, cancellationToken);

        return Ok(movies);
    }
}