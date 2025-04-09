using AutoMapper;
using BMDb.API.DTOs;
using BMDb.API.Models;

namespace BMDb.API.Mappings;

/// <inheritdoc />
public class AutoMapperProfiles : Profile
{
    /// <inheritdoc />
    public AutoMapperProfiles()
    {
        CreateMap<MovieDto, Movie>().ReverseMap();
        CreateMap<AddMovieRequestDto, Movie>().ReverseMap();
        CreateMap<UpdateMovieRequestDto, Movie>().ReverseMap();
    }
}