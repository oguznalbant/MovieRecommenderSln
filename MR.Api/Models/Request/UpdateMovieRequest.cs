namespace MR.Api.Models.Request
{
    public class UpdateMovieRequest
    {
        public int MovieId { get; set; }
        public string ToMailAddress { get; set; }
    }
}