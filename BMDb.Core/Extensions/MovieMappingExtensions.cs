namespace BMDb.Core.Extensions;

public static class MovieMappingExtensions
{
    public static MovieResponse ToDto(this Movie movie)
    {
        return new MovieResponse
        {
            Id = movie.Id,
            Title = movie.Title,
            Poster = movie.Poster,
            Trailer = movie.Trailer,
            Year = movie.Year,
            Director = movie.Director,
            Genres = movie.Genres,
            Plot = movie.Plot,
            ImdbId = movie.ImdbId
        };
    }


    public static Movie ToEntity(this AddMovieRequest request)
    {
        return new Movie
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Poster = request.Poster,
            Trailer = request.Trailer,
            Year = request.Year,
            Director = request.Director,
            Genres = request.Genres,
            Plot = request.Plot,
            ImdbId = request.ImdbId
        };
    }
}