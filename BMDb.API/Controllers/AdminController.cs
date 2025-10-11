namespace BMDb.API.Controllers;

/// <summary>
/// AdminController class is used to define the AdminController class.
/// </summary>
[Authorize("Admin")]
[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IAdminService _service;

    /// <summary>
    /// Constructor is used to inject the MovieContext class.
    /// </summary>
    /// <param name="service"></param>
    public AdminController(IAdminService service)
    {
        _service = service;
    }

    /// <summary>
    /// This method is used to add a movie.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("add-movie")]
    [ValidateModel]
    public async Task<IActionResult> AddMovieAsync([FromBody] AddMovieRequest request,
        CancellationToken cancellationToken = default)
    {
        var movie = await _service.AddMovieAsync(request, cancellationToken);

        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    /// <summary>
    /// This method is used to update a movie.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("update-movie")]
    [ValidateModel]
    public async Task<IActionResult> UpdateMovieAsync([FromBody] UpdateMovieRequest request,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _service.UpdateMovieAsync(request, cancellationToken));
    }

    /// <summary>
    /// This method is used to delete a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpDelete("delete-movie/{id:guid}")]
    public async Task<IActionResult> DeleteMovieAsync([FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        await _service.DeleteMovieAsync(id, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Get movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("get-by-id/{id:guid}")]
    public async Task<IActionResult> GetMovieById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        return Ok(await _service.GetMovieByIdAsync(id, cancellationToken));
    }
}