using AutoMapper;
using MR.Api.Entities;
using MR.Api.Models.Dto;
using MR.Api.Models.Response;

namespace MR.Api.Mapping
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<PopularMovieItemDto, Movie>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Title))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id.ToString()));

            CreateMap<Movie, MovieListItem>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id));
        }
    }
}
