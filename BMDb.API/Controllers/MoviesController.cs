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
    /// Constructor for the MoviesController
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
    public async Task<ActionResult<MovieResponse>> GetMoviesAsync([FromQuery] MoviesQueryDto dto,
        CancellationToken cancellationToken = default)
    {
        var movies = await _service.GetMoviesAsync(dto, cancellationToken);
        return Ok(movies);
    }


    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Guid>> GetMovieByIdAsync([FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var movie = await _service.GetMovieByIdAsync(id, cancellationToken);

        if (movie is not null)
        {
            return Ok(movie);
        }

        return NotFound();
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

    /// <summary>
    /// This method is used to get random movies.
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("random")]
    public async Task<IActionResult> GetRandomMoviesAsync([FromQuery] int limit = 10,
        CancellationToken cancellationToken = default)
    {
        var movies = await _service.GetRandomMoviesAsync(limit, cancellationToken);
        return Ok(movies);
    }
}