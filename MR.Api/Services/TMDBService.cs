using MR.Api.Models.Dto;
using System.Text.Json;

namespace MR.Api.Services
{
    public class TMDBService : ITMDBService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public TMDBService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _client = httpClientFactory.CreateClient();
            _client.BaseAddress = new Uri(configuration.GetValue<string>("ApiSettings:BaseUrl"));
            _configuration = configuration;
        }

        public async Task<PopularMovieListDto> GetPopularMoviesList()
        {
            PopularMovieListDto result = new PopularMovieListDto();
            try
            {
                var jsonResult = await _client.GetStringAsync($"movie/popular?api_key={_configuration.GetValue<string>("ApiSettings:ApiKey")}").ConfigureAwait(false);
                result = JsonSerializer.Deserialize<PopularMovieListDto>(jsonResult);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
