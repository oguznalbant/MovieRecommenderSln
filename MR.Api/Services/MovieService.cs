using AutoMapper;
using Hangfire;
using MR.Api.Entities;
using MR.Api.Models.Dto;
using MR.Api.Repositories;

namespace MR.Api.Services
{
    public class MovieService : IMovieService
    {
        private readonly ITMDBService _tmdbService;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public MovieService(ITMDBService tmdbService, IMapper mapper, IMovieRepository movieRepository)
        {
            _tmdbService = tmdbService;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        [Queue("moviefetch")]
        public async Task<bool> AutoFetchMovies()
        {
            try
            {
                var popularMovies = await _tmdbService.GetPopularMoviesList().ConfigureAwait(false);

                var mappedMovies = _mapper.Map<IEnumerable<PopularMovieItemDto>, IEnumerable<Movie>>(popularMovies.PopularMovieItems);

                await _movieRepository.CreateBulkMovie(mappedMovies).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }
    }
}
