using AutoMapper;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<MovieCreateDto, Movie>();
        CreateMap<MovieUpdateDto, Movie>();
        CreateMap<Movie, MovieCreateDto>();
    }
}