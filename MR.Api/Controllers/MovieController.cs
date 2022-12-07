using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MR.Api.Entities;
using MR.Api.Helper;
using MR.Api.Models.Dto;
using MR.Api.Models.Request;
using MR.Api.Models.Response;
using MR.Api.Repositories;
using MR.Api.Services;

namespace MR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly ITMDBService _tmdbService;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieController(IEmailSender emailSender, ITMDBService tmdbService, IMovieRepository movieRepository, IMapper mapper)
        {
            _emailSender = emailSender;
            _tmdbService = tmdbService;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<GetMovieResponse>> Get([FromQuery] GetMovieRequest request)
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<GetMovieListResponse>> GetList([FromQuery] GetMovieListRequest request)
        {
            return Ok();
        }

        [HttpPut(Name = "Update")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateMovieRequest request)
        {
            return Ok(true);
        }

        //[HttpPost(Name = "RecommendMovie")]
        //public async Task<ActionResult<bool>> RecommendMovie([FromBody] UpdateMovieRequest request)
        //{
        //    await _emailSender.SendEmailAsync("oguz.nalbant@gmail.com", "tests", "<p>ozz</p>").ConfigureAwait(false);
        //    return Ok(true);
        //}

        [HttpPost(Name = "AutoFetchMovies")]
        public async Task<ActionResult<int>> AutoFetchMovies([FromBody] AutoFetchMovieRequest request)
        {
            var popularMovies = await _tmdbService.GetPopularMoviesList().ConfigureAwait(false);

            var mappedMovies = _mapper.Map<IEnumerable<PopularMovieItemDto>, IEnumerable<Movie>>(popularMovies.PopularMovieItems);

            await _movieRepository.CreateBulkMovie(mappedMovies).ConfigureAwait(false);

            return Ok(0);
        }
    }
}
