namespace BMDb.API.Controllers;

/// <summary>
/// This class is used to define the MoviesController class.
/// </summary>
// [Authorize]
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
    [Authorize("User")]
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
    [Authorize("User")]
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
    /// This method is used to add a movie.
    /// </summary>
    /// <param name="requestDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize("Admin")]
    [HttpPost("add-movie")]
    [ValidateModel]
    public async Task<IActionResult> AddMovieAsync([FromBody] AddMovieRequestDto requestDto,
        CancellationToken cancellationToken = default)
    {
        var movie = await _service.AddMovieAsync(requestDto, cancellationToken);

        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    /// <summary>
    /// This method is used to update a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize("Admin")]
    [HttpPut("update-movie/{id:guid}")]
    [ValidateModel]
    public async Task<IActionResult> UpdateMovieAsync([FromRoute] Guid id, [FromBody] UpdateMovieRequestDto request,
        CancellationToken cancellationToken = default)
    {
        var movie = await _service.UpdateMovieAsync(id, request, cancellationToken);
        if (movie is null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    /// <summary>
    /// This method is used to delete a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [Authorize("Admin")]
    [HttpDelete("delete-movie/{id:guid}")]
    public async Task<IActionResult> DeleteMovieAsync([FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var movie = await _service.DeleteMovieAsync(id, cancellationToken);
        if (!movie)
        {
            return NotFound();
        }

        return NoContent();
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
    /// This method is used to get a movie by director.
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