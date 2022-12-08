namespace MR.Api.Models
{
    public interface IPagination : IPaginationRequest
    {
        public int TotalCount { get; set; }

        public int TotalPages { get; set; }
    }
}