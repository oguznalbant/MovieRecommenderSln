using Microsoft.AspNetCore.Mvc;
using MR.Api.Models.Dto;
using MR.Api.Models.Request;
using MR.Api.Models.Response;
using System.Text.Json;

namespace MR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TMDBController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public TMDBController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _client = httpClientFactory.CreateClient();
            _client.BaseAddress = new Uri(configuration.GetValue<string>("ApiSettings:BaseUrl"));
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<GetExternalMovieListResponse>> GetList([FromQuery] GetExternalMovieListRequest request)
        {
            var jsonResult = await _client.GetStringAsync($"movie/popular?api_key={_configuration.GetValue<string>("ApiSettings:ApiKey")}").ConfigureAwait(false);
            var popularMovies = JsonSerializer.Deserialize<PopularMovieListDto>(jsonResult);

            return Ok();
        }

        //[HttpGet]
        //[Route("")]
        //public async Task<ActionResult<GetExternalMovieListResponse>> Recommend([FromQuery] GetExternalMovieListRequest request)
        //{
        //    var jsonResult = await _client.GetStringAsync($"movie/popular?api_key={_configuration.GetValue<string>("ApiSettings:ApiKey")}").ConfigureAwait(false);
        //    var popularMovies = JsonSerializer.Deserialize<PopularMovieListDto>(jsonResult);

        //    return Ok();
        //}
    }
}
