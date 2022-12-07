using MR.Api.Models.Dto;

namespace MR.Api.Services
{
    public interface ITMDBService
    {
        Task<PopularMovieListDto> GetPopularMoviesList();
    }
}
