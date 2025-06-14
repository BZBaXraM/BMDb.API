namespace BMDb.Core.DTOs;

public class MoviesQueryDto
{
    public string? FilterOn { get; set; }
    public string? FilterQuery { get; set; }
    public string? SortBy { get; set; }
    public bool? IsAscending { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 100;
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public string? Director { get; set; }
    public int? Year { get; set; }
}