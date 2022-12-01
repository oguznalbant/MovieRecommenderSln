namespace MR.Api.Models.Response
{
    public class GetExternalMovieListResponse
    {
        public GetExternalMovieListResponse()
        {
        }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int PageIndex { get; set; }

        public IEnumerable<ExternalMovieListItem> MovieListItems { get; set; }
    }
}