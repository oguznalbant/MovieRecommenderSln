namespace MR.Api.Models.Response
{
    public class GetMovieListResponse : IPagination
    {
        public GetMovieListResponse()
        {
        }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<MovieListItem> MovieListItems { get; set; }
    }
}