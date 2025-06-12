namespace BMDb.Core.Mappings;

/// <inheritdoc />
public class AutoMapperProfiles : Profile
{
    /// <inheritdoc />
    public AutoMapperProfiles()
    {
        CreateMap<MovieResponse, Movie>().ReverseMap();
        CreateMap<AddMovieRequest, Movie>().ReverseMap();
        CreateMap<UpdateMovieRequest, Movie>().ReverseMap();
    }
}