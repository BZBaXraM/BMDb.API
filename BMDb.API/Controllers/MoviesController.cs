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
    [HttpGet]
    public async Task<IActionResult> GetMoviesAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
        [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100, [FromQuery] string? title = null,
        [FromQuery] string? genre = null,
        [FromQuery] string? director = null, [FromQuery] int? year = null,
        CancellationToken cancellationToken = default)
    {
        var movies = await _service.GetMoviesAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber,
            pageSize, title, genre, director, year, cancellationToken);

        return Ok(movies);
    }


    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
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