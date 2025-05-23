namespace BMDb.Domain.Entities;

/// <summary>
/// This class is used to define the Movie class.
/// </summary>
public class Movie
{
    /// <summary>
    /// This property is used to define the Id property.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// This property is used to define the Title property.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// This property is used to define the Poster property.
    /// </summary>
    public string? Poster { get; set; }

    /// <summary>
    /// This property is used to define the Trailer property.
    /// </summary>
    public string? Trailer { get; set; }

    /// <summary>
    /// This property is used to define the Year property.
    /// </summary>
    public string Year { get; set; } = string.Empty;

    /// <summary>
    /// This property is used to define the Director property.    
    /// </summary>
    public string Director { get; set; } = string.Empty;

    /// <summary>
    /// This property is used to define the Genre property.
    /// </summary>
    public List<string> Genres { get; set; } = [];

    /// <summary>
    /// This property is used to define the Plot property.
    /// </summary>
    public string? Plot { get; set; }

    /// <summary>
    /// This property is used to define the ImdbId property.
    /// </summary>
    public string ImdbId { get; set; } = string.Empty;
}