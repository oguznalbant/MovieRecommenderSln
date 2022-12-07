using AutoMapper;
using MR.Api.Entities;
using MR.Api.Models.Dto;

namespace MR.Api.Mapping
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<PopularMovieItemDto, Movie>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Title));
        }
    }
}
