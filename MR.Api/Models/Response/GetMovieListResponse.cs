namespace MR.Api.Models.Response
{
    public class GetMovieListResponse
    {
        public GetMovieListResponse()
        {
        }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int PageIndex { get; set; }

        public IEnumerable<MovieListItem> MovieListItems { get; set; }
    }
}