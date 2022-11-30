namespace MR.Api.Models.Request
{
    public class GetMovieListRequest : IPagination
    {
        public int PageSize { get; set; }
        
        public int TotalCount { get; set; }
        
        public int PageIndex { get; set; }
    }
}
