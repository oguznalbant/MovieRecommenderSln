namespace MR.Api.Models
{
    public interface IPaginationRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}