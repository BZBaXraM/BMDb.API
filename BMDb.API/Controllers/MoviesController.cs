using System.Text.Json;
using AutoMapper;
using BMDb.API.CustomFilters;
using BMDb.API.Data;
using BMDb.API.DTOs;
using BMDb.API.Models;
using BMDb.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMDb.API.Controllers;

/// <summary>
/// This class is used to define the MoviesController class.
/// </summary>
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _service;
    private readonly IMapper _mapper;
    private readonly ILogger<MoviesController> _logger;

    /// <summary>
    /// This constructor is used to inject the MovieContext class.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    public MoviesController(MovieContext context, IMapper mapper, ILogger<MoviesController> logger)
    {
        _service = new MovieService(context);
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// This method is used to get all movies.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetMoviesAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
        [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("GetMoviesAsync Action Method was invoked");
        _logger.LogWarning("This is a warring log");
        _logger.LogError("This is a error log");
        var movies = await _service.GetMoviesAsync(filterOn, filterQuery, sortBy,
            isAscending ?? true,
            pageNumber,
            pageSize, cancellationToken);
        _logger.LogInformation("Finished GetMoviesAsync request with data: {Serialize}",
            JsonSerializer.Serialize(movies));

        return Ok(_mapper.Map<IEnumerable<MovieDto>>(movies));
    }


    /// <summary>
    /// This method is used to get a movie by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetMovieById([FromRoute] Guid id, CancellationToken cancellationToken = default)
        => Ok(_mapper.Map<MovieDto>(await _service.GetMovieByIdAsync(id, cancellationToken)));


    /// <summary>
    /// This method is used to add a movie.
    /// </summary>
    /// <param name="requestDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> AddMovieAsync([FromBody] AddMovieRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        var movieModel = _mapper.Map<Movie>(requestDto);
        if (movieModel is null)
        {
            return NotFound();
        }

        var movieDto = _mapper.Map<MovieDto>(await _service.AddMovieAsync(movieModel, cancellationToken));
        return CreatedAtAction(nameof(GetMovieById), new { id = movieDto.Id }, movieDto);
    }

    /// <summary>
    /// This method is used to update a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ValidateModel]
    public async Task<IActionResult> UpdateMovieAsync([FromRoute] Guid id, [FromBody] UpdateMovieRequestDto request,
        CancellationToken cancellationToken = default)
    {
        var movieModel = _mapper.Map<Movie>(request);
        if (movieModel is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<MovieDto>(await _service.UpdateMovieAsync(id, movieModel, cancellationToken)));
    }

    /// <summary>
    /// This method is used to delete a movie.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteMovieAsync([FromRoute] Guid id,
        CancellationToken cancellationToken = default)
        => Ok(_mapper.Map<MovieDto>(await _service.DeleteMovieAsync(id, cancellationToken)));


    /// <summary>
    /// This method is used to get a movie by title.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("title/{title}")]
    public async Task<IActionResult> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default)
        => Ok(await _service.GetMovieByTitleAsync(title, cancellationToken));


    /// <summary>
    /// This method is used to get a movie by year.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("year/{year}")]
    public async Task<IActionResult> GetMovieByYearAsync(string year, CancellationToken cancellationToken = default)
        => Ok(await _service.GetMovieByYearAsync(year, cancellationToken));


    /// <summary>
    /// This method is used to get a movie by director.
    /// </summary>
    /// <param name="director"></param>
    /// <returns></returns>
    [HttpGet("director/{director}")]
    public async Task<IActionResult> GetMovieByDirectorAsync(string director)
        => Ok(await _service.GetMovieByDirectorAsync(director));


    /// <summary>
    /// This method is used to get a movie by genre.
    /// </summary>
    /// <param name="genre"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("genre/{genre}")]
    public async Task<IActionResult> GetMovieByGenreAsync(string genre, CancellationToken cancellationToken = default)
        => Ok(await _service.GetMovieByGenreAsync(genre, cancellationToken));

    /// <summary>
    /// This method is used to get a movie by imdb id.
    /// </summary>
    /// <param name="imdb"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("imdb/{imdb}")]
    public async Task<IActionResult> GetMovieByImdbIdAsync(string imdb, CancellationToken cancellationToken = default)
        => Ok(await _service.GetMovieByImdbIdAsync(imdb, cancellationToken));
}