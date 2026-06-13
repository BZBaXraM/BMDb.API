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
    public async Task<ActionResult<ResponseModel<List<MovieResponse>>>> GetMoviesAsync(
        [FromQuery] MoviesQueryResponse response,
        CancellationToken cancellationToken = default)
    {
        var responseModel = await _service.GetMoviesAsync(response, cancellationToken);
        return StatusCode(responseModel.StatusCode, responseModel);
    }


    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ResponseModel<MovieResponse>>> GetMovieByIdAsync([FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _service.GetMovieByIdAsync(id, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    /// <summary>
    /// This method is used to get a movie by imdb id.
    /// </summary>
    /// <param name="imdb"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("imdb/{imdb}")]
    public async Task<ActionResult<ResponseModel<IEnumerable<MovieResponse>>>> GetMovieByImdbIdAsync(string imdb,
        CancellationToken cancellationToken = default)
    {
        var response = await _service.GetMovieByImdbIdAsync(imdb, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    /// <summary>
    /// This method is used to get random movies.
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("random")]
    public async Task<ActionResult<ResponseModel<IEnumerable<MovieResponse>>>> GetRandomMoviesAsync(
        [FromQuery] int limit = 10,
        CancellationToken cancellationToken = default)
    {
        var response = await _service.GetRandomMoviesAsync(limit, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}