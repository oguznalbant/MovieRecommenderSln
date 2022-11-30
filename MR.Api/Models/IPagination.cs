namespace MR.Api.Models
{
    public interface IPagination
    {
        public int PageSize { get; set; }
        
        public int TotalCount { get; set; }
        
        public int PageIndex { get; set; }
    }
}