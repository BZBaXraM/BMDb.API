namespace BMDb.Core.Mappings;

/// <inheritdoc />
public class AutoMapperProfiles : Profile
{
    /// <inheritdoc />
    public AutoMapperProfiles()
    {
        CreateMap<MovieResponse, Movie>().ReverseMap();
        CreateMap<AddMovieRequestDto, Movie>().ReverseMap();
        CreateMap<UpdateMovieRequestDto, Movie>().ReverseMap();
    }
}