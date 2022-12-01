using System.Text.Json.Serialization;

namespace MR.Api.Models.Dto
{
    public class PopularMovieListDto : IPagination
    {
        [JsonIgnore]
        public int PageSize { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalCount { get; set; }

        [JsonPropertyName("Page")]
        public int PageIndex { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("results")]
        public IEnumerable<PopularMovieItemDto> PopularMovieItems { get; set; }
    }
}
